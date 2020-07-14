using SistemaBancario.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Repositorio
{
    public abstract class RepositoryBase<T> : IRepository<T> where T: IModelo
    {
        protected static RepositoryBase<T> _instancia;
        protected static List<T> _lista;

        public RepositoryBase()
        {

        }

        public static RepositoryBase<T> ObterInstancia<R>() where R: RepositoryBase<T>
        {
            if (_instancia == null)
            {
                _instancia = Activator.CreateInstance<R>();
            }

            return _instancia;
        }

        public void Create(T pObjeto)
        {
            pObjeto.Id = _lista?.Count > 0 ? _lista.Max(x => x.Id) + 1 : 1;
            pObjeto.DataCriacao = DateTime.Now;
            _lista.Add(pObjeto);
        }

        public void Delete(T pObjeto)
        {
            _lista.Remove(pObjeto);
        }

        public List<T> Read()
        {
            return _lista;
        }

        public virtual void Update(T pObjeto) { }
    }
}
