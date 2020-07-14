using Interfaces.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Implementacao
{
    public class IPardal : IAnimal, IAve, IAnimalVoador
    {
        public bool Comer()
        {
            return true;
        }

        public bool Dormir()
        {
            return true;
        }

        public void EmitirSom()
        {
            Console.WriteLine("Som de passaro cantando...");
        }

        public bool PossuiPenas()
        {
            return true;
        }

        public bool Voar()
        {
            return true;
        }
    }
}
