using SistemaBancario.Utils.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Core.Negocios
{
    public class LoginBll
    {
        public string UsuarioLogado { get; set; }

        public bool Autenticar(string pUsuario, string pSenha)
        {
            var usuarioBO = new UsuarioBll();
            var usuario = usuarioBO.ObterPeloNomeUsuario(pUsuario);

            if(usuario != null && usuario.Senha.Equals(pSenha))
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
