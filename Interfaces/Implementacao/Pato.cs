using Interfaces.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Implementacao
{
    public class Pato : IAnimal, IAnimalNadador, IAve
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
            Console.WriteLine("Quack Quack");
        }

        public bool Nadar()
        {
            return true;
        }

        public bool PossuiPenas()
        {
            return true;
        }
    }
}
