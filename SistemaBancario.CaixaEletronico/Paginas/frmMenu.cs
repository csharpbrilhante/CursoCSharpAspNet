using SistemaBancario.CaixaEletronico.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBancario.CaixaEletronico.Paginas
{
    public partial class frmMenu : Form, IPagina
    {
        public event AoFecharPagina Fechar;

        public frmMenu()
        {
            InitializeComponent();
        }     

        private void button5_Click(object sender, EventArgs e)
        {
            Fechar.Invoke();
        }
    }
}
