using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBancario.CaixaEletronico.Controls
{
    public partial class ucSessao : UserControl
    {
        public string Agencia
        {
            get { return lblAgencia.Text; }
            set { lblAgencia.Text = value; }
        }

        public string Conta
        {
            get { return lblConta.Text; }
            set { lblConta.Text = value; }
        }

        public string NomeCorrentista
        {
            get { return lblNomeCorrentista.Text; }
            set { lblNomeCorrentista.Text = value; }
        }

        public ucSessao()
        {
            InitializeComponent();
        }
    }
}
