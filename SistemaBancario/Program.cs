using SistemaBancario.Repositorio;
using System;
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
            
            using(var conexao = new Conexao())
            {
                try
                {
                    conexao.Migrate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao executar a migração de dados:\n{ex.Message}");
                    return;
                }
            }
            
            var login = new frmLogin();
            if(login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmPrincipal(login.UsuarioLogado));
            }
        }
    }
}
