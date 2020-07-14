using Interfaces.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Abstracao
{
    public abstract class AnimalBase : IAnimal
    {
        public bool Comer()
        {
            return true;
        }

        public bool Dormir()
        {
            return true;
        }

        public virtual void EmitirSom()
        {
            Console.WriteLine(ObterSom());
        }

        public abstract string ObterSom();
    }
}
