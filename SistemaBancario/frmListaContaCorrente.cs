using SistemaBancario.Core.Modelos;
using SistemaBancario.Core.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
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
            var lst = _contaCorrenteBO.ObterContasCorrentes();
            bs.DataSource = lst;
            gridContasCorrentes.DataSource = bs;

            button2.Enabled = lst?.Count > 0;
            button3.Enabled = button2.Enabled;
            mnAlterar.Enabled = button2.Enabled;
            mnExcluir.Enabled = button2.Enabled;
        }

        private void frmListaContaCorrente_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CarregarLista();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var contaSelecionada  = (ContaCorrente)gridContasCorrentes.SelectedRows[0].DataBoundItem;

            var frm = new frmCadastroContaCorrente(contaSelecionada);
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
                    if ((ContaCorrente)row.DataBoundItem != null)
                    {
                        row.Cells["CorrentistaNome"].Value = ((ContaCorrente)row.DataBoundItem).Correntista?.Nome ?? "";
                        row.Cells["CorrentistaCpfCnpj"].Value = ((ContaCorrente)row.DataBoundItem).Correntista?.CpfCnpj ?? "";
                    }
                }
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir a conta corrente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var contaSelecionada = (ContaCorrente)gridContasCorrentes.SelectedRows[0].DataBoundItem;

                _contaCorrenteBO.ExcluirContaCorrente(contaSelecionada);

                CarregarLista();
            }
        }

        //private void PreencherDadosDoCorrentistaDaContaCorrente(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    foreach (DataGridViewRow row in gridContasCorrentes.Rows)
        //    {
        //        if ((ContaCorrente)row.DataBoundItem != null)
        //        {
        //            row.Cells["CorrentistaNome"].Value = ((ContaCorrente)row.DataBoundItem).Correntista?.Nome ?? "";
        //            row.Cells["CorrentistaCpfCnpj"].Value = ((ContaCorrente)row.DataBoundItem).Correntista?.CpfCnpj ?? "";
        //        }
        //    }
        //}

        //private void gridContasCorrentes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    foreach (DataGridViewRow row in gridContasCorrentes.Rows)
        //    {
        //        if ((ContaCorrente)row.DataBoundItem != null)
        //        {
        //            row.Cells["CorrentistaNome"].Value = ((ContaCorrente)row.DataBoundItem).Correntista?.Nome ?? "";
        //            row.Cells["CorrentistaCpfCnpj"].Value = ((ContaCorrente)row.DataBoundItem).Correntista?.CpfCnpj ?? "";
        //        }
        //    }
        //}
    }
}
