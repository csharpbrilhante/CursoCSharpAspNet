using Animais.Abstracao;
using Animais.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animais.Implementacao
{
    public class Pato : Animal, IAve, IAnimalNadador
    {
        public Pato()
        {
            _nomeDoAnimal = "Pato";
        }
        public override string EmitirSom()
        {
            return "Quack Quack";
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
