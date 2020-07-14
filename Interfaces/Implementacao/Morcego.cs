using Interfaces.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Implementacao
{
    public class Morcego : IAnimal, IMamifero, IAnimalVoador
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
            Console.Write("Não emite som!");
        }

        public bool Mamar()
        {
            return true;
        }

        public bool Voar()
        {
            return true;
        }
    }
}
