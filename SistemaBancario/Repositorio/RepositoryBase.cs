using SistemaBancario.Contratos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Repositorio
{
    public abstract class RepositoryBase<T> : IRepository<T> where T: IModelo
    {
        protected Conexao _conexao;
        protected DbCommand _comando;
        protected string NomeTabela;
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

        

        
    }
}
