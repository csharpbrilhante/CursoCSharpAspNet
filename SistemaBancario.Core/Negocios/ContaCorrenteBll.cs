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
            return new CorrentistaBll().ObterCorrentistas(true);
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
        }
    }
}
