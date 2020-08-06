using SistemaBancario.Modelos;
using SistemaBancario.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,
                               "Validação",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            finally
            {
                CarregarLista();
            }
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
            try
            {
                gridCorrentistas.AutoGenerateColumns = false;
                CarregarLista();
            }
            finally
            {
                HabilitarDesabilitarControles();
            }
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
            try
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
            finally
            {
                CarregarLista();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Func<Correntista, bool> funcFiltro = null;

            if (rdbNome.Checked)
                funcFiltro = DelegadoConsultaNomeCorentista;
            else if (rdbCpf.Checked)
                funcFiltro = DelegadoConsultaPorCpf;

            var _listaTemp = _correntistas.Where(x => funcFiltro(x)).ToList();
            
            _datasource.DataSource = _listaTemp;
        }

        private bool DelegadoConsultaNomeCorentista(Correntista pCorrentista)
        {
            return pCorrentista.Nome.StartsWith(textBox1.Text) && 
                  (chkAtivos.Checked ? pCorrentista.Ativo : pCorrentista != null);
        }

        private bool DelegadoConsultaPorCpf(Correntista pCorrentista)
        {
            return pCorrentista.CpfCnpj.Equals(textBox1.Text) &&
                  (chkAtivos.Checked ? pCorrentista.Ativo : pCorrentista != null);
        }

        private void rdbCpf_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            _datasource.DataSource = _correntistas;
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            _datasource.DataSource = _correntistas;
        }
    }
}
