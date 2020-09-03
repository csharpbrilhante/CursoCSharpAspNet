using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Core.Dtos
{
    public class DadosDeposito
    {
        public string Agencia { get; private set; }
        public string NumeroConta { get; private set; }
        public decimal ValorDeposito { get; set; }

        public DadosDeposito(string pAgencia, string pNumeroConta, decimal pValorDeposito)
        {
            Agencia = pAgencia;
            NumeroConta = pNumeroConta;
            ValorDeposito = pValorDeposito;
        }
    }
}
