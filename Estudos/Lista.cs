using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos
{
    public class Lista<T>
    {
        private readonly List<T> _lista;

        public Lista()
        {
            _lista = new List<T>();
        }

        public List<T> ObterLista()
        {
            return _lista;
        }

        public void Add(T pObj)
        {
            _lista.Add(pObj);
        }

        public int Count => _lista.Count;
    }
}
