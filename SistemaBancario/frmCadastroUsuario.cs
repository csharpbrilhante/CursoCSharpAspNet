using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBancario
{
    public partial class frmCadastroUsuario : Form
    {
        private bool[] estadosBotoes = new bool[6] { true, true, true, true, true, true };

        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            
        }

    }
}
