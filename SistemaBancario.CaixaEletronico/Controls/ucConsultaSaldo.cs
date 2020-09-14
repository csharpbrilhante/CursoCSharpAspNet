using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaBancario.CaixaEletronico.Interfaces;
using SistemaBancario.CaixaEletronico.Negocios;

namespace SistemaBancario.CaixaEletronico.Controls
{
    public partial class ucConsultaSaldo : UserControl, IPagina
    {
        public ucConsultaSaldo()
        {
            InitializeComponent();
        }

        public event EventHandler Sair;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ucConsultaSaldo_Load(object sender, EventArgs e)
        {
            lblDataAtual.Text = string.Format(lblDataAtual.Text, "Em", DateTime.Now.ToString("dd/MM/yyyy"));
            lblValorSaldo.Text = new CaixaEletronicoBll().ConsultaSaldo().ToString("0.00");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sair?.Invoke(sender, e);
        }
    }
}
