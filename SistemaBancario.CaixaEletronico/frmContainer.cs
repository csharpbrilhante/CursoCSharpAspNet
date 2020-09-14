using SistemaBancario.CaixaEletronico.Controls;
using SistemaBancario.CaixaEletronico.Eventos;
using SistemaBancario.CaixaEletronico.Negocios;
using SistemaBancario.Core.Dtos;
using System;
using System.Windows.Forms;

namespace SistemaBancario.CaixaEletronico
{
    public partial class frmContainer : Form
    {
        private string _agencia;
        private string _contaCorrente;

        ucMenu menu; //vai ser acessado em várias ocasiões

        public frmContainer()
        {
            InitializeComponent();
        }

        private void frmContainer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Deseja realmente encerrar a sessão?", 
                                    "Encerrar sessão", 
                                    MessageBoxButtons.YesNo, 
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void ExibirMenu()
        {
            menu = new ucMenu();
            menu.Sair += ImplementacaoDoSairDoMenu;
            menu.ConsultaSaldo += ExibirSaldo;
            menu.RealizarDeposito += ExibirDeposito;
            menu.ExibirSaque += ExibirSaque;
            menu.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(menu);
        }

        private void ExibirSaldo(object sender, EventArgs e)
        {
            var uc = new ucConsultaSaldo();
            
            uc.Sair += (s, ev) =>
            {
                pnlContainer.Controls.Remove(uc);
                ExibirMenu();
            };

            pnlContainer.Controls.Remove(menu);
            pnlContainer.Controls.Add(uc);
        }

        private void ImplementacaoDoSairDoMenu(object sender, EventArgs e)
        {
            pnlContainer.Controls.Remove(menu);
            ExibirAcesso();
        }

        private void ExibirAcesso()
        {
            pnlSessao.Visible = false;

            var uc = new ucAcessoCC();
            
            uc.IniciarSessao += (s, e) =>
            {
                pnlSessao.Agencia = e.Agencia;
                pnlSessao.Conta = e.Conta;
                pnlSessao.NomeCorrentista = e.NomeCorrentista;

                pnlSessao.Visible = true;
                pnlContainer.Controls.Remove(uc);
                ExibirMenu();
            };
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void frmContainer_Load(object sender, EventArgs e)
        {
            ExibirAcesso();
        }

        private void ExibirDeposito(object sender, EventArgs e)
        {
            var uc = new ucDeposito();

            uc.Sair += (s, ev) =>
            {
                pnlContainer.Controls.Remove(uc);
                ExibirMenu();
            };

            pnlContainer.Controls.Remove(menu);
            pnlContainer.Controls.Add(uc);
        }

        private void ExibirSaque(object sender, EventArgs e)
        {
            var uc = new ucSaque();

            uc.Sacar += Sacar;

            uc.Sair += (s, ev) =>
            {
                pnlContainer.Controls.Remove(uc);
                ExibirMenu();
            };

            pnlContainer.Controls.Remove(menu);
            pnlContainer.Controls.Add(uc);
        }


        private void Sacar(object sender, ValorSaqueEventArgs e)
        {
            try
            {
                var CxBO = new CaixaEletronicoBll();
                CxBO.Sacar(e.Valor);
                MessageBox.Show($"Saque no valor de R$ {e.Valor.ToString("0.00")} realizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
