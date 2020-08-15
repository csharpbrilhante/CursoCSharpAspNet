using SistemaBancario.Core.Contratos;
using SistemaBancario.Utils.Db;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace SistemaBancario.Core.Repositorio
{
    public abstract class RepositoryBase<T> : IRepository<T> where T: IModelo
    {
        protected Conexao _conexao;
        protected DbCommand _comando;

        protected string Tabela;

        protected List<T> lista;

        public RepositoryBase()
        {
            _conexao = new Conexao();
        }

        public virtual void Create(T pObjeto)
        {
            pObjeto.Id = lista?.Count > 0 ? lista.Max(x => x.Id) + 1 : 1;
            pObjeto.DataCriacao = DateTime.Now;
            lista.Add(pObjeto);
        }

        public virtual List<T> Read()
        {
            return lista;
        }

        public abstract void Update(T pObjeto);

        public virtual void Delete(T pObjeto)
        {
            lista.Remove(pObjeto);
        }

        protected virtual int ObterProxSequencial()
        {
            var sql = $"SELECT VALOR + 1 FROM SEQUENCIAL WHERE SEQUENCIALID = '{Tabela.ToUpper()}'";
            var comando = _conexao.ObterComando();
            try
            {
                comando.CommandText = sql;
                var sequencial = System.Convert.ToInt32(comando.ExecuteScalar());
                comando.CommandText = $"UPDATE SEQUENCIAL SET VALOR = {sequencial} WHERE SEQUENCIALID = '{Tabela.ToUpper()}'";
                comando.ExecuteNonQuery();
                return sequencial;
            }
            finally
            {
                comando.Liberar();
            }
        }
    }
}
