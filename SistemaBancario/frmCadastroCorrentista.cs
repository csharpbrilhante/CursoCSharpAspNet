using SistemaBancario.Modelos;
using SistemaBancario.Negocios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaBancario
{
    public partial class frmCadastroCorrentista : Form
    {
        //criei o nosso "Dataset" de correntistas
        readonly CorrentistaBll _correntistaBO;
        private BindingSource _datasource;
        private Correntista _correntistaSelecionado = null;

        private List<Correntista> _correntistas;

        public frmCadastroCorrentista()
        {
            InitializeComponent();
            _correntistaBO = new CorrentistaBll();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            _correntistaSelecionado.Nome = txtNome.Text;
            _correntistaSelecionado.CpfCnpj = txtCpfCnpj.Text;
            _correntistaSelecionado.Ativo = chkAtivo.Checked;
            _correntistaBO.CriarOuAtualizarCorrentista(_correntistaSelecionado);

            //limpar tudo
            txtNome.Clear();
            txtCpfCnpj.Clear();
            chkAtivo.Checked = false;
            pnlEdicao.Enabled = false;
            btnNovo.Focus();
            _correntistaSelecionado = null;
            HabilitarDesabilitarControles();

        }

        private void CarregarLista()
        {
            _correntistas = _correntistaBO.ObterCorrentistas();
            _datasource = new BindingSource();
            _datasource.DataSource = _correntistas;
            gridCorrentistas.DataSource = _datasource;

        }

        private void frmCadastroCorrentista_Load(object sender, EventArgs e)
        {
            gridCorrentistas.AutoGenerateColumns = false;
            CarregarLista();
            HabilitarDesabilitarControles();
        }

        private void HabilitarDesabilitarControles()
        {
            _datasource.ResetBindings(true);
            btnNovo.Enabled = _correntistaSelecionado == null;
            btnAlterar.Enabled = _correntistas?.Count > 0 && _correntistaSelecionado == null;
            btnExcluir.Enabled = _correntistas?.Count > 0 && _correntistaSelecionado == null;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            pnlEdicao.Enabled = true;
            _correntistaSelecionado = new Correntista();
            txtNome.Focus();
            HabilitarDesabilitarControles();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _correntistaSelecionado = null;
            txtNome.Clear();
            txtCpfCnpj.Clear();
            chkAtivo.Checked = false;
            pnlEdicao.Enabled = false;
            btnNovo.Focus();
            HabilitarDesabilitarControles();
        }

        private void ObterItemSelecionado()
        {
            _correntistaSelecionado = (Correntista)gridCorrentistas.SelectedRows[0].DataBoundItem;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ObterItemSelecionado();
            pnlEdicao.Enabled = true;
            txtNome.Text = _correntistaSelecionado.Nome;
            txtCpfCnpj.Text = _correntistaSelecionado.CpfCnpj;
            chkAtivo.Checked = _correntistaSelecionado.Ativo;
            HabilitarDesabilitarControles();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ObterItemSelecionado();
            if (MessageBox.Show("Deseja excluir o correntista?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _correntistaBO.ExcluirCorrentista(_correntistaSelecionado);
                _correntistaSelecionado = null;
                HabilitarDesabilitarControles();
                MessageBox.Show("Correntista excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
