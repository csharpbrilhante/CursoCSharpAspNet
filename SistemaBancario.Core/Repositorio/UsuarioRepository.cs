using SistemaBancario.Core.Modelos;
using SistemaBancario.Utils.Db;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SistemaBancario.Utils.Seguranca;

namespace SistemaBancario.Core.Repositorio
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public UsuarioRepository() : base()
        {
            Tabela = "USUARIO";
        }

        public override void Create(Usuario pObjeto)
        {
            pObjeto.Id = ObterProxSequencial();
            pObjeto.DataCriacao = DateTime.Now;

            var sql = @"INSERT INTO USUARIO (USUARIOID, NOMEUSUARIO, SENHA, ATIVO, DATACRIACAO) 
                        VALUES (@USUARIOID, @NOMEUSUARIO, @SENHA, @ATIVO, @DATACRIACAO)";

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = sql;
                _comando.Parameters.Add(new SQLiteParameter("USUARIOID", pObjeto.Id));
                _comando.Parameters.Add(new SQLiteParameter("NOMEUSUARIO", pObjeto.NomeUsuario));
                _comando.Parameters.Add(new SQLiteParameter("SENHA", Cripto.Encrypt(pObjeto.Senha)));
                _comando.Parameters.Add(new SQLiteParameter("ATIVO", pObjeto.Ativo ? 1 : 0));
                _comando.Parameters.Add(new SQLiteParameter("DATACRIACAO", pObjeto.DataCriacao));
                _comando.ExecuteNonQuery();
            }
            finally
            {
                _comando.Liberar();
            }
        }

        public override void Update(Usuario pObjeto)
        {
            var sql = @"UPDATE USUARIO SET NOMEUSUARIO = @NOMEUSUARIO, SENHA = @SENHA, ATIVO = @ATIVO 
                        WHERE USUARIOID = @USUARIOID";

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = sql;
                _comando.Parameters.Add(new SQLiteParameter("USUARIOID", pObjeto.Id));
                _comando.Parameters.Add(new SQLiteParameter("NOMEUSUARIO", pObjeto.NomeUsuario));
                _comando.Parameters.Add(new SQLiteParameter("SENHA", Cripto.Encrypt(pObjeto.Senha)));
                _comando.Parameters.Add(new SQLiteParameter("ATIVO", pObjeto.Ativo ? 1 : 0));
                _comando.ExecuteNonQuery();
            }
            finally
            {
                _comando.Liberar();
            }
        }

        public override void Delete(Usuario pObjeto)
        {
            var sql = @"DELETE FROM USUARIO 
                        WHERE USUARIOID = @USUARIOID";

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = sql;
                _comando.Parameters.Add(new SQLiteParameter("USUARIOID", pObjeto.Id));
                _comando.ExecuteNonQuery();
            }
            finally
            {
                _comando.Liberar();
            }
        }

        public override List<Usuario> Read()
        {
            _comando = _conexao.ObterComando();
            lista = new List<Usuario>();
            try
            {
                _comando.CommandText = $"SELECT * FROM USUARIO";

                using (var reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Usuario()
                        {
                            Id = Convert.ToInt32(reader["USUARIOID"]),
                            NomeUsuario = reader["NOMEUSUARIO"].ToString(),
                            Senha = Cripto.Decrypt(reader["SENHA"].ToString()),
                            Ativo = Convert.ToInt32(reader["ATIVO"] ?? 0) == 1,
                            DataCriacao = Convert.ToDateTime(reader["DATACRIACAO"])
                        });
                    }

                    return base.Read();
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
    }
}
