using Animais.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animais.Abstracao
{
    public abstract class Animal : IAnimal
    {
        protected string _nomeDoAnimal;

        public string Nome => _nomeDoAnimal;

        public bool Comer()
        {
            return true;
        }

        public bool Dormir()
        {
            return true;
        }

        //métodos substituíveis
        public virtual string EmitirSom()
        {
            throw new NotImplementedException();
        }
    }
}
