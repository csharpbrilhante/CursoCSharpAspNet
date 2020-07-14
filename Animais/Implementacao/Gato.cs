using Animais.Abstracao;
using Animais.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animais.Implementacao
{
    public class Gato : Mamifero
    {
        public Gato()
        {
            _nomeDoAnimal = "Gato";
        }
        public override string EmitirSom()
        {
            return "Miauuuuu!";
        }
    }
}
