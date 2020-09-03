using System;
using System.Windows.Forms;
using SistemaBancario.CaixaEletronico.Interfaces;
using SistemaBancario.CaixaEletronico.Negocios;
using SistemaBancario.Core.Dtos;
using SistemaBancario.Core.Enumerados;

namespace SistemaBancario.CaixaEletronico.Controls
{
    public partial class ucDeposito : UserControl, IPagina
    {
        private int PaginaSelecionada = 0;

        private readonly CaixaEletronicoBll _caixaEletronicoBO = new CaixaEletronicoBll();

        public ucDeposito()
        {
            InitializeComponent();

            pnlSessao.Agencia = CaixaEletronicoBll.SessaoInfo.Agencia;
            pnlSessao.Conta = CaixaEletronicoBll.SessaoInfo.NumeroConta;
            pnlSessao.Agencia = CaixaEletronicoBll.SessaoInfo.NomeCorrentista;

        }

        public event EventHandler Sair;

        private void button1_Click(object sender, EventArgs e)
        {
            Sair?.Invoke(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (tbcContas.SelectedIndex)
            {
                case (int)EnDestinoDeposito.MinhaConta: 
                    DepositarNaMinhaConta(); 
                    break;
                
                case (int)EnDestinoDeposito.OutraConta:
                    DepositarEmOutraConta();
                    break;
                
                default: 
                    break;
            }
        }

        private void DepositarNaMinhaConta()
        {
            _caixaEletronicoBO.Depositar(new DadosDeposito(CaixaEletronicoBll.SessaoInfo.Agencia, CaixaEletronicoBll.SessaoInfo.NumeroConta, Convert.ToDecimal(txtValorDeposito.Text)));
        }

        private void DepositarEmOutraConta()
        {
            _caixaEletronicoBO.Depositar(new DadosDeposito(txtAgencia.Text, txtContaCorrente.Text, Convert.ToDecimal(txtValorDeposito.Text)));
        }
    }
}
