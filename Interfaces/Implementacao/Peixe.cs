using Interfaces.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Implementacao
{
    public class Peixe : IAnimal, IAnimalNadador
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
            throw new NotImplementedException(); //não emite som
        }

        public bool Nadar()
        {
            return true;
        }
    }
}
