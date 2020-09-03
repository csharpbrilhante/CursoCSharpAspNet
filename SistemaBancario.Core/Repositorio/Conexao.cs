using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaBancario.Core.Repositorio
{
    public class Conexao : IDisposable
    {
        protected SQLiteConnection conexao;

        public Conexao()
        {
            conexao = new SQLiteConnection(@"Data Source=bancario.db; Version = 3; New = True;");
        }

        public SQLiteCommand ObterComando()
        {
            conexao.Open();
            return conexao.CreateCommand();
        }

        public void Dispose()
        {
            conexao.Close();
            conexao.Dispose();
            conexao = null;
        }

        public void Migrate()
        {
            var comando = this.ObterComando();
            try
            {
                var migracoes = new Dictionary<int, string>
                {
                    { 1, versao01() },
                    { 2, versao02() },
                    { 3, versao03() },
                    { 4, versao04() },
                    { 5, versao05() },
                    { 6, versao06() },
                    { 7, Versao07() },
                    { 8, Versao08() },
                    { 9, Versao09() },
                };

                comando.Transaction = comando.Connection.BeginTransaction();
                comando.CommandText = "select coalesce(max(versaoid), 0) + 1 from versao";

                //na verdade, é melhor tratar a proxima versão a ser aplicada
                int proximaMigracao;

                try
                {
                    proximaMigracao = Convert.ToInt32(comando.ExecuteScalar());
                }
                catch
                {
                    proximaMigracao = 1;
                }

                for (int migracao = proximaMigracao; migracao <= migracoes.Count; migracao++)
                {
                    comando.CommandText = migracoes[migracao];
                    comando.ExecuteNonQuery();
                    //atualiza a versão, coma ultima versão aplicada
                    comando.CommandText = $"INSERT INTO VERSAO (VERSAOID, DATAHORA) VALUES ({migracao}, CURRENT_TIMESTAMP);";
                    comando.ExecuteNonQuery();
                }

                comando.Transaction.Commit();
            }
            catch
            {
                comando.Transaction.Rollback();
                throw;
            }
            finally
            {
                comando.Dispose();
            }
        }

        public string Versao09()
        {
            return @"UPDATE CONTACORRENTE SET SENHA = 'DP96fCMhxRAMnrrhWdot3y6BBFbx49RWOa+sYbbt0L1H68xTDLk8ihQVj6cIZqdl6QLBdkcO4KluVAQm55k6rYmYseeG/Rr0OPpbFJSbrGvgGta0y8D0L8gxj300Qnp/';";
        }

        public string Versao08()
        {
            return @"ALTER TABLE CONTACORRENTE ADD SENHA TEXT;";
        }

        public string Versao07()
        {
            return @"CREATE UNIQUE INDEX IDX_UNQ_CONTACORRENTE_NUMCONTA
                    ON CONTACORRENTE(NUMCONTA)";
        }

        public string versao06()
        {
            return @"INSERT INTO SEQUENCIAL (SEQUENCIALID, VALOR) VALUES 
                    ('CONTACORRENTE', 0);";
        }

        public string versao05()
        {
            return @"CREATE TABLE CONTACORRENTE(
                          CONTACORRENTEID INTEGER PRIMARY KEY AUTOINCREMENT,
                          AGENCIA TEXT NOT NULL,
                          NUMCONTA TEXT NOT NULL,
                          CORRENTISTAID INTEGER NOT NULL,
                          FOREIGN KEY(CORRENTISTAID) REFERENCES CORRENTISTA(CORRENTISTAID)
                    );";
        }

        public string versao04()
        {
            return @"INSERT INTO SEQUENCIAL (SEQUENCIALID, VALOR) VALUES 
                    ('CORRENTISTA', 0);";
        }

        public string versao03()
        {
            return @"INSERT INTO SEQUENCIAL (SEQUENCIALID, VALOR) VALUES 
                    ('USUARIO', (SELECT COALESCE(MAX(USUARIOID), 1) FROM USUARIO));";
        }

        public string versao02()
        {
            return @"CREATE TABLE IF NOT EXISTS [SEQUENCIAL] (
                        [SEQUENCIALID] TEXT  NOT NULL PRIMARY KEY,
                        [VALOR] INTEGER DEFAULT 1 NOT NULL
                        );";
        }

        public string versao01()
        {
            var senhaCriptografada = "C6lw+S97VY7utO5Zhn1RemtNKYDL7RLbFgeXSEtMzFc0rlbWHMsB3siYoUmxr2jKLjGix0vS8EdFoYylHc54GFORuSOLg76oFpsO3e4ghIEknXQ4r4QfyzH5O3+6p9S7";

            return $@"CREATE TABLE IF NOT EXISTS [VERSAO] (
                        [VERSAOID] INTEGER  NOT NULL PRIMARY KEY,
                        [DATAHORA] TIMESTAMP DEFAULT CURRENT_TIME NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS [USUARIO] (
                        [USUARIOID] INTEGER  NOT NULL PRIMARY KEY,
                        [NOMEUSUARIO] TEXT NOT NULL,
                        [SENHA] TEXT NOT NULL,
                        [ATIVO] INTEGER DEFAULT 0 NOT NULL,
                        [DATACRIACAO] TIMESTAMP DEFAULT CURRENT_TIME NOT NULL
                        );
                        
                        INSERT INTO USUARIO (USUARIOID, NOMEUSUARIO, SENHA, ATIVO) VALUES (1, 'root', 
                        '{senhaCriptografada}', 
                        1); 
                        
                        CREATE TABLE IF NOT EXISTS [CORRENTISTA] (
                        [CORRENTISTAID] INTEGER  NOT NULL PRIMARY KEY,
                        [NOME] TEXT NOT NULL,
                        [CPFCNPJ] TEXT NOT NULL,
                        [ATIVO] INTEGER DEFAULT 0 NOT NULL,
                        [DATACRIACAO] TIMESTAMP DEFAULT CURRENT_TIME NOT NULL,
                         UNIQUE(CPFCNPJ)
                        );

                        CREATE UNIQUE INDEX IF NOT EXISTS [CORRENTISTA_CPFCNPJ_CPJCNPJ] ON [CORRENTISTA](
                        [CPFCNPJ]  ASC
                        );";
        }
    }
}
