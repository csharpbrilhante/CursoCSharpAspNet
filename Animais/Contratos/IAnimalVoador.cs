using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animais.Contratos
{
    public interface IAnimalVoador: IAnimal
    {
        bool Voar();
    }
}
