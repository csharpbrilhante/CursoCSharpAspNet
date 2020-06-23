using SistemaBancario.Negocios;
using System;
using System.Windows.Forms;

namespace SistemaBancario
{
    public partial class frmLogin : Form
    {
        LoginBll loginBO;

        public frmLogin()
        {
            InitializeComponent();
            loginBO = new LoginBll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            var isAutenticado = loginBO.Autenticar(txtUsuario.Text, txtSenha.Text);

            if (isAutenticado)
                MessageBox.Show("Autenticado");
            else
                MessageBox.Show("Usuário ou senha inválido");            
        }
    }
}
