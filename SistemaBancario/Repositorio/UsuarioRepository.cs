using SistemaBancario.Modelos;
using SistemaBancario.Utils.Db;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace SistemaBancario.Repositorio
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public UsuarioRepository() : base()
        {
            NomeTabela = "USUARIO";
        }

        public override void Create(Usuario pObjeto)
        {
            pObjeto.Id = lista?.Count > 0 ? lista.Max(x => x.Id) + 1 : 1;
            pObjeto.DataCriacao = DateTime.Now;

            var sql = @"INSERT INTO USUARIO (USUARIOID, NOMEUSUARIO, SENHA, ATIVO, DATACRIACAO) 
                        VALUES (@USUARIOID, @NOMEUSUARIO, @SENHA, @ATIVO, @DATACRIACAO)";

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = sql;
                _comando.Parameters.Add(new SQLiteParameter("USUARIOID", pObjeto.Id));
                _comando.Parameters.Add(new SQLiteParameter("NOMEUSUARIO", pObjeto.NomeUsuario));
                _comando.Parameters.Add(new SQLiteParameter("SENHA", pObjeto.Senha));
                _comando.Parameters.Add(new SQLiteParameter("ATIVO", pObjeto.Ativo ? 1 : 0));
                _comando.Parameters.Add(new SQLiteParameter("DATACRIACAO", pObjeto.DataCriacao));
                _comando.ExecuteNonQuery();

                lista.Add(pObjeto);
            }
            finally
            {
                _comando.Liberar();
            }
        }

        public override void Update(Usuario pObjeto)
        {
            var usuarioAtualizar = lista.FirstOrDefault(x => x.Id == pObjeto.Id);
            usuarioAtualizar.NomeUsuario = pObjeto.NomeUsuario;
            usuarioAtualizar.Senha = pObjeto.Senha;
        }

        public override List<Usuario> Read()
        {
            _comando = _conexao.ObterComando();
            lista = new List<Usuario>();
            try
            {
                _comando.CommandText = $"Select * from {NomeTabela}";

                using (var reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Usuario()
                        {
                            Id = Convert.ToInt32(reader["USUARIOID"]),
                            NomeUsuario = reader["NOMEUSUARIO"].ToString(),
                            Senha = reader["SENHA"].ToString(),
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
