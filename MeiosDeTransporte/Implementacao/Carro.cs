using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiosDeTransporte.Implementacao
{
    public abstract class Carro
    {
        protected string _combustivel;
        public string Combustivel
        {
            get { return _combustivel; }
        }
    }
}
