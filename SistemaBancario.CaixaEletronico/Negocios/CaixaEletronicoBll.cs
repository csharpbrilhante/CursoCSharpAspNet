using core = SistemaBancario.Core.Negocios; //usei um alias para o namespace por causa da duplicidade de nomes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaBancario.Core.Dtos;

namespace SistemaBancario.CaixaEletronico.Negocios
{
    public class CaixaEletronicoBll
    {
        public static Sessao SessaoInfo { get; set; }

        private readonly core.CaixaEletronicoBll _contaCorrenteBO = new core.CaixaEletronicoBll();
        private readonly core.MovimentacoesBll _movimentacoesBO = new core.MovimentacoesBll();

        public Sessao AcessarConta(string pAgencia, string pConta, string pSenha)
        {
            return _contaCorrenteBO.AcessarConta(pAgencia, pConta, pSenha);
        }

        public void Depositar(DadosDeposito pDadosConta)
        {
            _movimentacoesBO.Depositar(pDadosConta);
        }
    }
}
