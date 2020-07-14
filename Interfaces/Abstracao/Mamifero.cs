using Interfaces.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Abstracao
{
    public abstract class Mamifero : AnimalBase, IMamifero
    {
        public bool Mamar()
        {
            return true;
        }
    }
}
