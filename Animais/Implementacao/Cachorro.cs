using Animais.Abstracao;
using Animais.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animais.Implementacao
{
    public class Cachorro : Mamifero
    {
        public Cachorro()
        {
            _nomeDoAnimal = "Cachorro";
        }

        public override string EmitirSom()
        {
            return "Au Au Au";
        }
    }
}
