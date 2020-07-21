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
    public partial class frmCadastroUsuario : Form
    {
        private string _senhaOriginal;

        private Usuario _usuarioSelecionado;
        private readonly UsuarioBll _usuarioBO = new UsuarioBll();
        private List<Usuario> _usuarios;

        private BindingSource _datasource;

        private bool[] estadosBotoes = new bool[6] { true, true, true, true, true, true };

        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ObterItemSelecionado(true);
            LimparCampos();
            SetarModoDeEdicao();
        }

        private void LimparCampos()
        {
            txtNomeUsuario.Clear();
            txtSenha.Clear();
            txtConfirmaSenha.Clear();
        }

        private void CarregarLista()
        {
            _usuarios = _usuarioBO.ObterUsuarios();
            _datasource = new BindingSource();
            _datasource.DataSource = _usuarios;
            gridUsuarios.DataSource = _datasource;
        }

        private void SetarModoDeEdicao()
        {
            try
            {
                Habilitar(new int[] { 3, 4, 5 });
                Desabilitar(new int[] { 0, 1, 2 });
                txtNomeUsuario.Focus();
            }
            finally
            {
                AtualizarEstados();
            }
        }

        private void SetarModoReadOnly()
        {
            try
            {
                Habilitar(new int[] { 0, 1, 2 });
                Desabilitar(new int[] { 3, 4, 5 });
            }
            finally
            {
                estadosBotoes[1] = _usuarios?.Count > 0;
                estadosBotoes[2] = _usuarios?.Count > 0;
                AtualizarEstados();
            }
        }

        private void AtualizarEstados()
        {
            btnNovo.Enabled     = estadosBotoes[0];
            btnAlterar.Enabled  = estadosBotoes[1];
            btnExcluir.Enabled  = estadosBotoes[2];
            btnCancelar.Enabled = estadosBotoes[3];
            btnSalvar.Enabled   = estadosBotoes[4];
            pnlEdicao.Enabled   = estadosBotoes[5];
            _datasource.ResetBindings(true);
        }

        private void Habilitar(int[] pIndices)
        {
            for (int i = 0; i < pIndices.Length; i++)
            {
                estadosBotoes[pIndices[i]] = true;
            }
        }

        private void Desabilitar(int[] pIndices)
        {
            for (int i = 0; i < pIndices.Length; i++)
            {
                estadosBotoes[pIndices[i]] = false;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ObterItemSelecionado();
            txtNomeUsuario.Text = _usuarioSelecionado.NomeUsuario;
            txtSenha.Text = _usuarioSelecionado.Senha;
            SetarModoDeEdicao();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                ObterItemSelecionado();
                if (MessageBox.Show("Deseja realmente excluir o registro", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _usuarioBO.ExcluirUsuario(_usuarioSelecionado);
                    LimparCampos();
                }
            }
            finally
            {
                SetarModoReadOnly();
            }
        }

        private void ObterItemSelecionado(bool pNovo = false)
        {
            try
            {
                if (pNovo)
                    _usuarioSelecionado = new Usuario();
                else
                    _usuarioSelecionado = (Usuario)gridUsuarios.SelectedRows[0].DataBoundItem;
            }
            finally
            {
                _senhaOriginal = _usuarioSelecionado.Senha ?? string.Empty;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            SetarModoReadOnly();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                _usuarioSelecionado.NomeUsuario = txtNomeUsuario.Text;
                _usuarioSelecionado.Senha = txtSenha.Text;
                if(_usuarioBO.CriarOuAtualizarUsuario(_usuarioSelecionado, MensagemDeErro, ValidarConfirmacaoSenha))
                {
                    LimparCampos();
                    SetarModoReadOnly();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu o erro: {ex.Message}");
            }
        }

        private void ValidarConfirmacaoSenha()
        {
            if(txtSenha.Text != _senhaOriginal && txtSenha.Text != txtConfirmaSenha.Text)
                throw new Exception("As senhas informadas não conferem.");
        }

        private void MensagemDeErro(string pMensagem)
        {
            MessageBox.Show($"Ocorreu o erro: {pMensagem}");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                gridUsuarios.AutoGenerateColumns = false;
                CarregarLista();
            }
            finally
            {
                SetarModoReadOnly();
            }            
        }

        private void frmCadastroUsuario_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
