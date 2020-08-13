using SistemaBancario.Modelos;
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
    public partial class frmListaContaCorrente : Form
    {
        private readonly ContaCorrenteBll _contaCorrenteBO = new ContaCorrenteBll();
        private ContaCorrente _contaCorrenteSelecionada = null;

        public frmListaContaCorrente()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var frm = new frmCadastroContaCorrente();
            frm.ShowDialog();
            CarregarLista();
        }

        private void CarregarLista()
        {
            var bs = new BindingSource();
            bs.DataSource = _contaCorrenteBO.ObterContasCorrentes();
            gridContasCorrentes.DataSource = bs;
        }

        private void frmListaContaCorrente_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();

            CarregarLista();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _contaCorrenteSelecionada  = (ContaCorrente)gridContasCorrentes.SelectedRows[0].DataBoundItem;

            var frm = new frmCadastroContaCorrente(_contaCorrenteSelecionada);
            frm.ShowDialog();
            CarregarLista();
        }

        private void ConfigurarDataGridView()
        {
            gridContasCorrentes.AutoGenerateColumns = false;

            //isso aqui é um outro jeito de criar um delegate e atribuir a um evento, neste caso da gridview
            //Na próxima aula irei explicar a teoria sobre isso
            gridContasCorrentes.DataBindingComplete += (s, ev) =>
            {
                foreach (DataGridViewRow row in gridContasCorrentes.Rows)
                {
                    if((ContaCorrente)row.DataBoundItem != null)
                    {
                        row.Cells["CorrentistaNome"].Value = ((ContaCorrente)row.DataBoundItem).Correntista?.Nome ?? "";
                        row.Cells["CorrentistaCpfCnpj"].Value = ((ContaCorrente)row.DataBoundItem).Correntista?.CpfCnpj ?? "";
                    }
                }
            };
        }
    }
}
