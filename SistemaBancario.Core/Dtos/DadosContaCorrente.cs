using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Core.Dtos
{
    public class DadosContaCorrente
    {
        public string Agencia { get; private set; }
        public string NumeroConta { get; private set; }
        public DadosContaCorrente(string pAgencia, string pNumeroConta)
        {
            Agencia = pAgencia;
            NumeroConta = pNumeroConta;
        }
    }
}
