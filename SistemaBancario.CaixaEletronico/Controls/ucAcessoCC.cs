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

namespace SistemaBancario.CaixaEletronico.Controls
{
    public partial class ucAcessoCC : UserControl
    {
        public event EventHandler<ContaEventArgs> IniciarSessao;

        public ucAcessoCC()
        {
            InitializeComponent();
        }

        private void Acessar()
        {
            if (txtAgencia.Text == "1234" && txtContaCorrente.Text == "123456" && txtSenha.Text == "0000")
            {
                IniciarSessao.Invoke(this,
                                 new ContaEventArgs(txtAgencia.Text, txtContaCorrente.Text));
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
