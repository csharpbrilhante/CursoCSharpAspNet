using SistemaBancario.Core.Dtos;
using SistemaBancario.Core.Modelos;
using SistemaBancario.Core.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario.Core.Negocios
{
    public class ContaCorrenteBll
    {
        private readonly ContaCorrenteRepository _dataset = new ContaCorrenteRepository();
        private readonly CorrentistaBll correntistaBll = new CorrentistaBll();

        public void CriarOuAtualizar(ContaCorrente pContaCorrente)
        {
            Validar(pContaCorrente);

            var contaExistente = _dataset.Read().FirstOrDefault(x => x.Id == pContaCorrente.Id);

            if (contaExistente == null)
                _dataset.Create(pContaCorrente);
            else
                _dataset.Update(pContaCorrente);
        }

        public List<ContaCorrente> ObterContasCorrentes()
        {
            return _dataset.Read();
        }

        public List<Correntista> ObterCorrentistas()
        {
            return correntistaBll.ObterCorrentistas(true);
        }

        public int ObterNumeroConta()
        {
            return new Random().Next(0, 999999);
        }

        public void ExcluirContaCorrente(ContaCorrente pContaCorrente)
        {
            _dataset.Delete(pContaCorrente);
        }

        private void Validar(ContaCorrente pContaCorrente)
        {
            if (string.IsNullOrWhiteSpace(pContaCorrente.Agencia.Trim()))
                throw new Exception("Número da agência não foi informado.");

            if (string.IsNullOrWhiteSpace(pContaCorrente.Senha.Trim()) || pContaCorrente.Senha.Trim().ToUpper() == "2K21")
                throw new Exception("Senha reservada ao sistema ou inválida.\nFavor solicite a criação da senha!");
        }

        public Sessao ValidarAcessoContaCorrente(string pAgencia, string pConta, string pSenha)
        {
            var conta = _dataset.Read()
                .FirstOrDefault(cc => cc.Agencia == pAgencia && cc.NumConta == pConta);

            if(conta != null && conta.Senha == pSenha)
            {
                return new Sessao() {
                        Agencia = conta.Agencia,
                        NumeroConta = conta.NumConta,
                        NomeCorrentista = conta.Correntista.Nome
                };
            }

            return null;
        }
    }
}
