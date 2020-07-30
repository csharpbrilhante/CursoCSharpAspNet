using SistemaBancario.Utils.Seguranca;
using System;
using System.Windows.Forms;

namespace SistemaBancario.Cripto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtResultado.Text = txtOriginal.Text.Encrypt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtResultado.Text = txtOriginal.Text.Decrypt();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtResultado.Text);
        }
    }
}
