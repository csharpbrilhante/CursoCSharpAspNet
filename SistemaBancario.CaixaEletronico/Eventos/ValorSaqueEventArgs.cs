using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.CaixaEletronico.Eventos
{
    public class ValorSaqueEventArgs : EventArgs
    {
        public decimal Valor { get; private set; }

        public ValorSaqueEventArgs(decimal pValor)
        {
            Valor = pValor;
        }
    }
}
