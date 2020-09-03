using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.CaixaEletronico.Eventos
{
    public class ContaEventArgs: EventArgs
    {
        public string Agencia { get; private set; }
        public string Conta { get; private set; }
        public string NomeCorrentista { get; private set; }

        public ContaEventArgs(string pAgencia, string pConta, string pNomeCorrentista)
        {
            Agencia = pAgencia;
            Conta = pConta;
            NomeCorrentista = pNomeCorrentista;
        }
    }
}
