using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaBancario.CaixaEletronico.Eventos;
using SistemaBancario.CaixaEletronico.Negocios;

namespace SistemaBancario.CaixaEletronico.Controls
{
    public partial class ucAcessoCC : UserControl
    {


        private CaixaEletronicoBll CaixaEletronicoBO = new CaixaEletronicoBll();

        public event EventHandler<ContaEventArgs> IniciarSessao;

        public ucAcessoCC()
        {
            InitializeComponent();
        }

        private void Acessar()
        {
            var sessao = CaixaEletronicoBO.AcessarConta(txtAgencia.Text, txtContaCorrente.Text, txtSenha.Text);
            
            if (sessao != null)
            {
                IniciarSessao.Invoke(this,
                                 new ContaEventArgs(sessao.Agencia, sessao.NumeroConta, sessao.NomeCorrentista));

                CaixaEletronicoBll.SessaoInfo = sessao;
            }
            else
            {
                MessageBox.Show("Agência, conta corrente ou senha inválidos.",
                                "Acesso a conta corrente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                txtAgencia.Clear();
                txtContaCorrente.Clear();
                txtSenha.Clear();
                txtAgencia.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Acessar();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                Acessar();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
