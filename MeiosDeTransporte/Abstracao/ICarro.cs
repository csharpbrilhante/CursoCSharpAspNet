using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiosDeTransporte.Abstracao
{
    public interface ICarro
    {
        string Combustivel { get; }
        void Abastecer(string pCombustivel);
    }
}
