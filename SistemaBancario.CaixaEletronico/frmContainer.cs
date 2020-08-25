﻿using SistemaBancario.CaixaEletronico.Controls;
using SistemaBancario.CaixaEletronico.Eventos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBancario.CaixaEletronico
{
    public partial class frmContainer : Form
    {
        private string _agencia;
        private string _contaCorrente;

        ucMenu menu; //vai ser acessado em várias ocasiões

        public frmContainer()
        {
            InitializeComponent();
        }

        private void frmContainer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Deseja realmente encerrar a sessão?", 
                                    "Encerrar sessão", 
                                    MessageBoxButtons.YesNo, 
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void ExibirMenu()
        {
            menu = new ucMenu();
            menu.Sair += ImplementacaoDoSairDoMenu;
            menu.ConsultaSaldo += ExibirSaldo;
            menu.RealizarDeposito += ExibirDeposito;
            menu.ExibirSaque += ExibirSaque;
            menu.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(menu);
        }

        private void ExibirSaldo(object sender, EventArgs e)
        {
            var uc = new ucConsultaSaldo();
            
            uc.Sair += (s, ev) =>
            {
                pnlContainer.Controls.Remove(uc);
                ExibirMenu();
            };

            pnlContainer.Controls.Remove(menu);
            pnlContainer.Controls.Add(uc);
        }

        private void ImplementacaoDoSairDoMenu(object sender, EventArgs e)
        {
            pnlContainer.Controls.Remove(menu);
            ExibirAcesso();
        }

        private void ExibirAcesso()
        {
            pnlSessao.Visible = false;

            var uc = new ucAcessoCC();
            
            uc.IniciarSessao += (s, e) =>
            {
                _agencia = e.Agencia;
                _contaCorrente = e.Conta;
                lblAgencia.Text = _agencia;
                lblConta.Text = _contaCorrente;
                pnlSessao.Visible = true;
                pnlContainer.Controls.Remove(uc);
                ExibirMenu();
            };
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void frmContainer_Load(object sender, EventArgs e)
        {
            ExibirAcesso();
        }

        private void ExibirDeposito(object sender, EventArgs e)
        {
            var uc = new ucDeposito();

            uc.Sair += (s, ev) =>
            {
                pnlContainer.Controls.Remove(uc);
                ExibirMenu();
            };

            pnlContainer.Controls.Remove(menu);
            pnlContainer.Controls.Add(uc);
        }

        private void ExibirSaque(object sender, EventArgs e)
        {
            var uc = new ucSaque();

            uc.Sacar10 += Sacar;
            uc.Sacar20 += Sacar;
            uc.Sacar50 += Sacar;
            uc.Sacar100 += Sacar;
            uc.Sacar200 += Sacar;
            uc.Sacar500 += Sacar;

            uc.Sair += (s, ev) =>
            {
                pnlContainer.Controls.Remove(uc);
                ExibirMenu();
            };

            pnlContainer.Controls.Remove(menu);
            pnlContainer.Controls.Add(uc);
        }


        private void Sacar(object sender, ValorSaqueEventArgs e)
        {
            //realiza o saque conforme o valor devolvido no evento
            MessageBox.Show($"Vc seleciobou o valor R$ {e.Valor.ToString("0.00")}");
        }
    }
}
