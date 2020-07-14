using Animais.Abstracao;
using Animais.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animais.Implementacao
{
    public class Golfinho : Mamifero, IAnimalNadador
    {
        public Golfinho()
        {
            _nomeDoAnimal = "Golfinho";
        }
        public override string EmitirSom()
        {
            return "Eeeee Eee Eeee"; //fonte: https://rodapedohorizonte.wordpress.com/2012/10/12/eeeee-eee-eeee/
        }
        public bool Nadar()
        {
            return true;
        }
    }
}
