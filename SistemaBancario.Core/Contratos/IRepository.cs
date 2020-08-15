using System.Collections.Generic;

namespace SistemaBancario.Core.Contratos
{
    public interface IRepository<T> where T: IModelo
    {
        void Create(T pObjeto);
        List<T> Read();
        void Update(T pObjeto);
        void Delete(T pObjeto);
    }
}
