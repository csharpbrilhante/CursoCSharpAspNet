using Animais.Abstracao;
using Animais.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animais.Implementacao
{
    public class Morcego : Mamifero, IAnimalVoador
    {
        public Morcego()
        {
            _nomeDoAnimal = "Morcego";
        }
        public bool Voar()
        {
            return true;
        }

        public override string EmitirSom()
        {
            return "Não emite som";
        }
    }
}
