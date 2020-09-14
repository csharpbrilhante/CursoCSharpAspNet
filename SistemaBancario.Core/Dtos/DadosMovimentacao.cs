using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Core.Dtos
{
    public class DadosMovimentacao
    {
        public string Agencia { get; private set; }
        public string NumeroConta { get; private set; }
        public decimal Valor { get; set; }

        public DadosMovimentacao(string pAgencia, string pNumeroConta, decimal pValorDeposito)
        {
            Agencia = pAgencia;
            NumeroConta = pNumeroConta;
            Valor = pValorDeposito;
        }
    }
}
