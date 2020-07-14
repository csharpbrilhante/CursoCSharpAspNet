using Animais.Abstracao;
using Animais.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animais.Implementacao
{
    public class Peixe : Animal, IAnimalNadador
    {
        public Peixe()
        {
            _nomeDoAnimal = "Peixe";
        }
        public bool Nadar()
        {
            return true;
        }

        public override string EmitirSom()
        {
            return "Não emite som";
        }
    }
}
