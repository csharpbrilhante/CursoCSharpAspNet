using Interfaces.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Abstracao
{
    //Nota: IMplementar Mamifero voador

    public abstract class AveVoadora : Ave, IAnimalVoador
    {
        public bool Voar()
        {
            return true;
        }
    }
}
