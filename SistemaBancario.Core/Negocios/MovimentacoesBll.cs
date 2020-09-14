using SistemaBancario.Core.Dtos;
using SistemaBancario.Core.Modelos;
using SistemaBancario.Core.Repositorio;
using System;
using System.Linq;

namespace SistemaBancario.Core.Negocios
{
    public class MovimentacoesBll
    {
        private readonly MovimentacaoCCRepository _datasetMovimentacao = new MovimentacaoCCRepository();
        private readonly ContaCorrenteRepository _datasetContaCorrente = new ContaCorrenteRepository();

        private const string TEXTO_PARA_DEPOSITO = "(+) DEP. CC.";
        private const string TEXTO_PARA_SAQUE = "(-) SAQUE CX. ELET. CC.";

        public void Depositar(DadosMovimentacao pDadosMovimentacao)
        {
            if (pDadosMovimentacao.Valor <= 0)
                throw new Exception("Valor do depósito inválido");

            var conta = _datasetContaCorrente.Read()
                            .FirstOrDefault(x => x.Agencia == pDadosMovimentacao.Agencia &&
                                            x.NumConta == pDadosMovimentacao.NumeroConta);

            if (conta == null)
                throw new Exception("Conta informada para o depósito inválida.");

            var movimentacao = new MovimentacaoCC()
            {
                ContaCorrenteId = conta.Id,
                DataMovimentacao = DateTime.Now,
                Historico = TEXTO_PARA_DEPOSITO,
                Valor = pDadosMovimentacao.Valor
            };

            _datasetMovimentacao.Create(movimentacao);
        }

        public void Sacar(DadosMovimentacao pDadosMovimentacao) 
        {
            if (pDadosMovimentacao.Valor <= 0)
                throw new Exception("Valor do saque inválido");

            var conta = _datasetContaCorrente.Read()
                            .FirstOrDefault(x => x.Agencia == pDadosMovimentacao.Agencia &&
                                            x.NumConta == pDadosMovimentacao.NumeroConta);

            if (conta == null)
                throw new Exception("Conta informada para o depósito inválida.");

            ValidarSaldoContaCorrente(conta, pDadosMovimentacao.Valor);

            var movimentacao = new MovimentacaoCC()
            {
                ContaCorrenteId = conta.Id,
                DataMovimentacao = DateTime.Now,
                Historico = TEXTO_PARA_SAQUE,
                Valor = pDadosMovimentacao.Valor * -1
            };

            _datasetMovimentacao.Create(movimentacao);
        }

        private void ValidarSaldoContaCorrente(ContaCorrente pContaCorrente, decimal pValor)
        {
            var saldo = _datasetContaCorrente.ConsultaSaldoContaCorrente(pContaCorrente);

            saldo = saldo - pValor;

            if(saldo <= 0)
            {
                throw new Exception("Saldo insuficiente para a operação");
            }
        }

        public decimal ConsultaSaldo(DadosContaCorrente pDadosContaCorrente)
        {
            var conta = _datasetContaCorrente.Read()
                            .FirstOrDefault(x => x.Agencia == pDadosContaCorrente.Agencia &&
                                            x.NumConta == pDadosContaCorrente.NumeroConta);

            return _datasetContaCorrente.ConsultaSaldoContaCorrente(conta);
        }
    }
}
