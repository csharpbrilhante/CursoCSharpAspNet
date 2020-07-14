using Interfaces.Abstracao;
using Interfaces.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Implementacao
{
    //refatorar

    public class Cachorro : Mamifero //primeiro de IMamifero
    {
        public bool Comer()
        {
            return true;
        }

        public bool Dormir()
        {
            return true;
        }

        public bool Mamar()
        {
            return true;
        }

        public override string ObterSom()
        {
            return "Au Au Au";
        }
    }
}
