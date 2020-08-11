using SistemaBancario.Negocios;
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
    public partial class frmCadastroContaCorrente : Form
    {
        private readonly ContaCorrenteBll ContaCorrenteBO = new ContaCorrenteBll();
        public frmCadastroContaCorrente()
        {
            InitializeComponent();

            BindingSource bs = new BindingSource();
            bs.DataSource = ContaCorrenteBO.ObterCorrentistas();
            cbxCorrentistas.DataSource = bs;
            cbxCorrentistas.ValueMember = "Id";
            cbxCorrentistas.DisplayMember = "Nome";
        }
    }
}
