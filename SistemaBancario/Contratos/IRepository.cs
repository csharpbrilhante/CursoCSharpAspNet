using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Contratos
{
    public interface IRepository<T> where T: IModelo
    {
        void Create(T pObjeto);
        List<T> Read();
        void Update(T pObjeto);
        void Delete(T pObjeto);
    }
}
