using SistemaBancario.Core.Modelos;
using SistemaBancario.Core.Negocios;
using SistemaBancario.Utils.Helpers;
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

        ContaCorrente _contaCorrenteSelecionada = null;

        public frmCadastroContaCorrente()
        {
            InitializeComponent();
            CarregarCorrentistas();
            _contaCorrenteSelecionada = new ContaCorrente();
            _contaCorrenteSelecionada.NumConta = ContaCorrenteBO.ObterNumeroConta().ToString("000000");
            txtNumConta.Text = _contaCorrenteSelecionada.NumConta;
        }

        private void CarregarCorrentistas()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ContaCorrenteBO.ObterCorrentistas();
            cbxCorrentistas.DataSource = bs;
            cbxCorrentistas.ValueMember = "Id";
            cbxCorrentistas.DisplayMember = "Nome";
        }

        public frmCadastroContaCorrente(ContaCorrente pContaCorrente)
        {
            InitializeComponent();
            //quando a conta corrent vem do form de consulta
            CarregarCorrentistas();
            txtAgencia.Text = pContaCorrente.Agencia;
            txtNumConta.Text = pContaCorrente.NumConta;
            cbxCorrentistas.SelectedValue = pContaCorrente.CorrentistaId;

            _contaCorrenteSelecionada = pContaCorrente;
        }

        private void txtAgencia_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAgencia.Text.Trim())){
                try
                {
                    //txtAgencia.Text = Convert.ToInt32(txtAgencia.Text).ToString("0000");
                    txtAgencia.Text = txtAgencia.Text.PadLeft(4, '0');
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Agencia inválida, Erro: {ex.Message}");
                }
            }
        }

        private void txtAgencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.SomenteNumeros();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                _contaCorrenteSelecionada.Agencia = txtAgencia.Text;
                _contaCorrenteSelecionada.CorrentistaId = Convert.ToInt32(cbxCorrentistas.SelectedValue);
                ContaCorrenteBO.CriarOuAtualizar(_contaCorrenteSelecionada);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu o erro ao tentar salvar a conta corrente: {ex.Message}");
            }
        }
    }
}
