using Animais.Abstracao;
using Animais.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animais.Implementacao
{
    public class Pardal: Animal, IAveVoadora
    {
        public Pardal()
        {
            _nomeDoAnimal = "Pardal";
        }
        public override string EmitirSom()
        {
            return "Piu Piu Piu";
        }

        public bool PossuiPenas()
        {
            return true;
        }

        public bool Voar()
        {
            return true;
        }
    }
}
