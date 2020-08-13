using SistemaBancario.Modelos;
using SistemaBancario.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Negocios
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

        private void Validar(ContaCorrente pContaCorrente)
        {
            if (string.IsNullOrWhiteSpace(pContaCorrente.Agencia.Trim()))
                throw new Exception("Número da agência não foi informado.");
        }
    }
}
