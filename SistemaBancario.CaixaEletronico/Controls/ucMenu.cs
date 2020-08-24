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

namespace SistemaBancario.CaixaEletronico.Controls
{
    public partial class ucMenu : UserControl, IPagina
    {
        public ucMenu()
        {
            InitializeComponent();
        }

        public event EventHandler Sair;

        private void button5_Click(object sender, EventArgs e)
        {
            Sair.Invoke(sender, e);
        }
    }
}
