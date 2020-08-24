using SistemaBancario.CaixaEletronico.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBancario.CaixaEletronico
{
    public partial class frmContainer : Form
    {
        private string _agencia;
        private string _contaCorrente;

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

        ucMenu menu;

        private void ExibirMenu()
        {
            menu = new ucMenu();
            menu.Sair += ImplementacaoDoSairDoMenu;
            pnlContainer.Controls.Add(menu);
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
                _agencia = e.Agencia;
                _contaCorrente = e.Conta;
                lblAgencia.Text = _agencia;
                lblConta.Text = _contaCorrente;
                pnlSessao.Visible = true;
                pnlContainer.Controls.Remove(uc);
                ExibirMenu();
            };

            pnlContainer.Controls.Add(uc);
        }

        private void frmContainer_Load(object sender, EventArgs e)
        {
            ExibirAcesso();
        }
    }
}
