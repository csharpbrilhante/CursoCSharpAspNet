using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animais.Contratos
{
    public interface IAnimal
    {
        bool Comer();
        bool Dormir();
        string EmitirSom();
        string Nome { get; }
    }
}
