using Interfaces.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Implementacao
{
    //refatorar

    public class Gato : IAnimal, IMamifero
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
            Console.WriteLine("Miauuuu!");
        }

        public bool Mamar()
        {
            return true;
        }
    }
}
