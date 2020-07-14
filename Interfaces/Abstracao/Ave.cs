using Interfaces.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Abstracao
{
    public abstract class Ave : AnimalBase, IAve
    {
        public bool PossuiPenas()
        {
            return true;
        }
    }
}
