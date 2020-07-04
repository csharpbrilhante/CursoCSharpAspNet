using SistemaBancario.Modelos;
using SistemaBancario.Negocios;
using SistemaBancario.Repositorio;
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
    public partial class frmCadastroCorrentista : Form
    {
        //criei o nosso "Dataset" de correntistas
        readonly CorrentistaBll _correntistaBO;
        private BindingSource _datasource;

        public frmCadastroCorrentista()
        {
            InitializeComponent();
            _correntistaBO = new CorrentistaBll();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //criei uma nova instancia de corretista
            var novoCorrentista = new Correntista();

            //atribui os dados do novo correntista para a instancia do novo correntista
            novoCorrentista.Nome = txtNome.Text;
            novoCorrentista.CpfCnpj = txtCpfCnpj.Text;

            //invoquei o metodo create do dataset
            _correntistaBO.CriarOuAtualizarCorrentista(novoCorrentista);
            _datasource.ResetBindings(true);

        }

        private void CarregarLista()
        {
            var correntistas = _correntistaBO.ObterCorrentistas();
            _datasource = new BindingSource();
            _datasource.DataSource = correntistas;
            gridCorrentistas.DataSource = _datasource;

        }

        private void frmCadastroCorrentista_Load(object sender, EventArgs e)
        {
            CarregarLista();
        }
    }
}
