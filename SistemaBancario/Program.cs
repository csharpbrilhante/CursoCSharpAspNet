using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBancario
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var login = new frmLogin();
            if(login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmPrincipal(login.UsuarioLogado));
            }
        }
    }
}
