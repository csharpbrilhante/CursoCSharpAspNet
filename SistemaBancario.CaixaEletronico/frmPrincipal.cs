using SistemaBancario.CaixaEletronico.Interfaces;
using SistemaBancario.CaixaEletronico.Paginas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBancario.CaixaEletronico
{
    public partial class frmPrincipal : Form
    {
        Form[] _formularios = new Form[1]
        {
            new frmMenu()
        };

        int _formularioAtivo = -1;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ExibirInicio();  
        }

        private void ExibirInicio()
        {
            var frm = new frmInicio();
            ExibirFormulario(frm, "Pressione uma tecla para iniciar", false);
        }

        private void AcaoAoFecharFormularioAtivo()
        {
            if(_formularioAtivo >= 0)
            {
                _formularios[_formularioAtivo].Hide();
                _formularioAtivo--;
            }
        }

        private void ExibirFormulario(int pIndice, string pTitulo)
        {
            lblTitulo.Text = pTitulo;
            ConfigurarLayoutBasico(_formularios[pIndice]);
            
            (_formularios[pIndice] as IPagina).Fechar += () =>
            {
                AcaoAoFecharFormularioAtivo();
            };

            _formularioAtivo = pIndice;

            _formularios[pIndice].Show();
        }

        private void ConfigurarLayoutBasico(Form pForm)
        {
            pForm.MdiParent = this;
            pForm.FormBorderStyle = FormBorderStyle.None;
            pForm.Dock = DockStyle.Fill;
            pForm.BackColor = ColorTranslator.FromHtml("#407294");
        }

        private void ExibirFormulario(Form pForm, string pTitulo, bool PodeFechar = true)
        {
            lblTitulo.Text = pTitulo;
            ConfigurarLayoutBasico(pForm);
            pForm.Show();
        }

        private void frmPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
                       
        }

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ExibirFormulario(0, "Menu Inicial");
        }
    }
}
