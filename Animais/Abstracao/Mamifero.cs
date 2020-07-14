using Animais.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animais.Abstracao
{
    public abstract class Mamifero : Animal, IMamifero
    {
        public bool Mamar()
        {
            return true;
        }
    }
}
