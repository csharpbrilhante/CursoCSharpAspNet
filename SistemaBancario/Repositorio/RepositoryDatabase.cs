using SistemaBancario.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Repositorio
{
    public abstract class RepositoryDatabase<T> : IRepository<T> where T : IModelo
    {
        #region métodos para obter os comandos Sql
        protected string InsertSql()
        {
            throw new NotImplementedException();
        }

        protected string UpdateSql()
        {
            throw new NotImplementedException();
        }
        protected string DeleteSql()
        {
            throw new NotImplementedException();
        }

        protected string SelectSql()
        {
            throw new NotImplementedException();
        }

        #endregion

        public void Create(T pObjeto)
        {
            throw new NotImplementedException();
        }

        public void Delete(T pObjeto)
        {
            throw new NotImplementedException();
        }

        public List<T> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(T pObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
