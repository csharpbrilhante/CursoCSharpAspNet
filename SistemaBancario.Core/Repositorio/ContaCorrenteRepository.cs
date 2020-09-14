using SistemaBancario.Core.Modelos;
using SistemaBancario.Utils.Db;
using SistemaBancario.Utils.Seguranca;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaBancario.Core.Repositorio
{
    public class ContaCorrenteRepository : RepositoryBase<ContaCorrente>
    {
        public ContaCorrenteRepository(): base()
        {
            Tabela = "CONTACORRENTE";
        }

        public override void Create(ContaCorrente pObjeto)
        {
            pObjeto.Id = ObterProxSequencial();
            pObjeto.DataCriacao = DateTime.Now;

            var sql = @"INSERT INTO CONTACORRENTE (AGENCIA, NUMCONTA, CORRENTISTAID, SENHA) VALUES (@AGENCIA, @NUMCONTA, @CORRENTISTAID, @SENHA)";

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = sql;
                _comando.Parameters.Add(new SQLiteParameter("AGENCIA", pObjeto.Agencia));
                _comando.Parameters.Add(new SQLiteParameter("NUMCONTA", pObjeto.NumConta));
                _comando.Parameters.Add(new SQLiteParameter("SENHA", Cripto.Encrypt(pObjeto.Senha)));
                _comando.Parameters.Add(new SQLiteParameter("CORRENTISTAID", pObjeto.CorrentistaId));

                _comando.ExecuteNonQuery();
            }
            finally
            {
                _comando.Liberar();
            }
        }

        public override List<ContaCorrente> Read()
        {
            lista = new List<ContaCorrente>();

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = @"SELECT *
                                            FROM CONTACORRENTE CC
                                            JOIN CORRENTISTA C ON C.CORRENTISTAID = CC.CORRENTISTAID";
                
                using(var reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var contacorrente = new ContaCorrente();
                        contacorrente.Id = Convert.ToInt32(reader["CONTACORRENTEID"]);
                        contacorrente.Agencia = reader["AGENCIA"].ToString();
                        contacorrente.NumConta = reader["NUMCONTA"].ToString();
                        contacorrente.CorrentistaId = Convert.ToInt32(reader["CORRENTISTAID"]);
                        contacorrente.Senha = Cripto.Decrypt(reader["SENHA"].ToString());


                        contacorrente.Correntista = new Correntista()
                        {
                            Id = Convert.ToInt32(reader["CORRENTISTAID"]),
                            Nome = reader["NOME"].ToString(),
                            CpfCnpj = reader["CPFCNPJ"].ToString(),
                            Ativo = Convert.ToInt16(reader["ATIVO"] ?? 0) == 1,
                            DataCriacao = Convert.ToDateTime(reader["DATACRIACAO"])
                        };

                        lista.Add(contacorrente);
                    }

                    return lista;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _comando.Liberar();
            }
        }

        public override void Update(ContaCorrente pObjeto)
        {
            var sql = @"UPDATE CONTACORRENTE SET AGENCIA = @AGENCIA, NUMCONTA = @NUMCONTA, CORRENTISTAID = @CORRENTISTAID, 
                        SENHA = @SENHA WHERE CONTACORRENTEID = @CONTACORRENTEID";

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = sql;
                _comando.Parameters.Add(new SQLiteParameter("CONTACORRENTEID", pObjeto.Id));
                _comando.Parameters.Add(new SQLiteParameter("AGENCIA", pObjeto.Agencia));
                _comando.Parameters.Add(new SQLiteParameter("NUMCONTA", pObjeto.NumConta));
                _comando.Parameters.Add(new SQLiteParameter("CORRENTISTAID", pObjeto.CorrentistaId));
                _comando.Parameters.Add(new SQLiteParameter("SENHA", Cripto.Encrypt(pObjeto.Senha)));
                _comando.ExecuteNonQuery();
            }
            finally
            {
                _comando.Liberar();
            }
        }

        public override void Delete(ContaCorrente pObjeto)
        {
            var sql = @"DELETE FROM CONTACORRENTE 
                        WHERE CONTACORRENTEID = @CONTACORRENTEID";

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = sql;
                _comando.Parameters.Add(new SQLiteParameter("CONTACORRENTEID", pObjeto.Id));
                _comando.ExecuteNonQuery();
            }
            finally
            {
                _comando.Liberar();
            }
        }

        public decimal ConsultaSaldoContaCorrente(ContaCorrente pContaCorrente)
        {
            var sql = $@"SELECT SUM(VALOR) AS SALDO FROM MOVIMENTACAOCC
                        WHERE CONTACORRENTEID = @CONTACORRENTEID";

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = sql;
                _comando.Parameters.Add(new SQLiteParameter("CONTACORRENTEID", pContaCorrente.Id));
                return Convert.ToDecimal(_comando.ExecuteScalar());
            }
            finally
            {
                _comando.Liberar();
            }
        }
    }
}
