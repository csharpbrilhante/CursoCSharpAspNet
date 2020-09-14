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
            try
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

                MessageBox.Show("Depósito realizado com sucesso!");

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimparCampos()
        {
            txtAgencia.Clear();
            txtContaCorrente.Clear();
            txtValorDeposito.Text = "0,00";
            tbcContas.SelectedIndex = (int)EnDestinoDeposito.MinhaConta;
        }

        private void DepositarNaMinhaConta()
        {
            try
            {
                _caixaEletronicoBO.Depositar(new DadosMovimentacao(CaixaEletronicoBll.SessaoInfo.Agencia, CaixaEletronicoBll.SessaoInfo.NumeroConta, Convert.ToDecimal(txtValorDeposito.Text)));
            }
            catch
            {
                throw;
            }
        }

        private void DepositarEmOutraConta()
        {
            try
            {
                _caixaEletronicoBO.Depositar(new DadosMovimentacao(txtAgencia.Text, txtContaCorrente.Text, Convert.ToDecimal(txtValorDeposito.Text)));
            }
            catch
            {
                throw;
            }
        }
    }
}
