using SistemaBancario.Core.Dtos;

namespace SistemaBancario.Core.Negocios
{
    public class CaixaEletronicoBll
    {
        private readonly ContaCorrenteBll _contaCorrenteBO = new ContaCorrenteBll();

        public Sessao AcessarConta(string pAgencia, string pConta, string pSenha)
        {
            return _contaCorrenteBO.ValidarAcessoContaCorrente(pAgencia, pConta, pSenha);
        }
    }
}
