using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Negocios
{
    public class LoginBll
    {
        //ATRIBUTOS PRIVADOS - NÃO VISÍVEIS FORA DO ESCOPO
        const string usuario = "usuario";
        const string senha = "123456";

        //Sintaxe propriedade auto (prop)
        public string UsuarioLogado { get; set; }

        //Sintaxe de propriedade completa (propfull)
        //private string _usuarioLogado;

        //public string UsuarioLogado
        //{
        //    get { return _usuarioLogado; }
        //    set { _usuarioLogado = value; }
        //}


        public bool Autenticar(string pUsuario, string pSenha)
        {
            if(pUsuario == usuario && pSenha == senha)
            {
                UsuarioLogado = pUsuario;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
