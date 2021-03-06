﻿using SistemaBancario.Core.Modelos;
using SistemaBancario.Utils.Db;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaBancario.Core.Repositorio
{
    public class CorrentistaRepository : RepositoryBase<Correntista>
    {
        public CorrentistaRepository(): base()
        {
            Tabela = "CORRENTISTA";
        }

        public override void Create(Correntista pObjeto)
        {
            pObjeto.Id = ObterProxSequencial();
            pObjeto.DataCriacao = DateTime.Now;

            var sql = @"INSERT INTO CORRENTISTA (CORRENTISTAID,  NOME, CPFCNPJ, ATIVO, DATACRIACAO) VALUES (@CORRENTISTAID,  @NOME, @CPFCNPJ, @ATIVO, @DATACRIACAO)";

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = sql;
                _comando.Parameters.Add(new SQLiteParameter("CORRENTISTAID", pObjeto.Id));
                _comando.Parameters.Add(new SQLiteParameter("NOME", pObjeto.Nome));
                _comando.Parameters.Add(new SQLiteParameter("CPFCNPJ", pObjeto.CpfCnpj));
                _comando.Parameters.Add(new SQLiteParameter("ATIVO", pObjeto.Ativo ? 1 : 0));
                _comando.Parameters.Add(new SQLiteParameter("DATACRIACAO", pObjeto.DataCriacao));
                _comando.ExecuteNonQuery();
            }
            finally
            {
                _comando.Liberar();
            }
        }

        public override void Delete(Correntista pObjeto)
        {
            var sql = @"DELETE FROM CORRENTISTA 
                        WHERE CORRENTISTAID = @CORRENTISTAID";

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = sql;
                _comando.Parameters.Add(new SQLiteParameter("CORRENTISTAID", pObjeto.Id));
                _comando.ExecuteNonQuery();
            }
            finally
            {
                _comando.Liberar();
            }
        }

        public override void Update(Correntista pObjeto)
        {
            var sql = @"UPDATE CORRENTISTA SET NOME = @NOME, CPFCNPJ = @CPFCNPJ, ATIVO = @ATIVO 
                        WHERE CORRENTISTAID = @CORRENTISTAID";

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = sql;
                _comando.Parameters.Add(new SQLiteParameter("CORRENTISTAID", pObjeto.Id));
                _comando.Parameters.Add(new SQLiteParameter("NOME", pObjeto.Nome));
                _comando.Parameters.Add(new SQLiteParameter("CPFCNPJ", pObjeto.CpfCnpj));
                _comando.Parameters.Add(new SQLiteParameter("ATIVO", pObjeto.Ativo ? 1 : 0));
                _comando.ExecuteNonQuery();
            }
            finally
            {
                _comando.Liberar();
            }
        }

        public override List<Correntista> Read()
        {
            lista = new List<Correntista>();
            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = "SELECT * FROM CORRENTISTA";

                using(var reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var correntista = new Correntista();
                        correntista.Id = Convert.ToInt32(reader["CORRENTISTAID"]);
                        correntista.Nome = reader["NOME"].ToString();
                        correntista.CpfCnpj = reader["CPFCNPJ"].ToString();
                        correntista.Ativo = Convert.ToInt16(reader["ATIVO"] ?? 0) == 1;
                        correntista.DataCriacao = Convert.ToDateTime(reader["DATACRIACAO"]);

                        lista.Add(correntista);
                    }

                    return lista;
                }
            }
            catch(Exception ex)
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
