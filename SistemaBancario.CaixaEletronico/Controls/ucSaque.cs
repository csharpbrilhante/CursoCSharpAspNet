using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaBancario.CaixaEletronico.Interfaces;
using SistemaBancario.CaixaEletronico.Eventos;
using System.Runtime.Remoting.Channels;

namespace SistemaBancario.CaixaEletronico.Controls
{
    public partial class ucSaque : UserControl, IPagina
    {
        public ucSaque()
        {
            InitializeComponent();
        }

        public event EventHandler Sair;

        public event EventHandler<ValorSaqueEventArgs> Sacar10;
        public event EventHandler<ValorSaqueEventArgs> Sacar20;
        public event EventHandler<ValorSaqueEventArgs> Sacar50;
        public event EventHandler<ValorSaqueEventArgs> Sacar100;
        public event EventHandler<ValorSaqueEventArgs> Sacar200;
        public event EventHandler<ValorSaqueEventArgs> Sacar500;

        private void button1_Click(object sender, EventArgs e)
        {
            Sacar10?.Invoke(sender, new ValorSaqueEventArgs(10));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sacar10?.Invoke(sender, new ValorSaqueEventArgs(20));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sacar10?.Invoke(sender, new ValorSaqueEventArgs(50));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sacar10?.Invoke(sender, new ValorSaqueEventArgs(100));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sacar10?.Invoke(sender, new ValorSaqueEventArgs(200));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sacar10?.Invoke(sender, new ValorSaqueEventArgs(500));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Sair?.Invoke(sender, e);
        }
    }
}
