using SistemaBancario.Core.Modelos;
using SistemaBancario.Core.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario.Core.Negocios
{
    public class UsuarioBll
    {
        private readonly UsuarioRepository _dataset = new UsuarioRepository();
        
        public bool CriarOuAtualizarUsuario(Usuario pUsuario, Action<string> pCallbackErro, Action pValidaConfirmacaoSenha)
        {
            try
            {
                Validar(pUsuario);
                pValidaConfirmacaoSenha.Invoke();
                
                var usuarioExistente = _dataset.Read().FirstOrDefault(x => x.Id == pUsuario.Id);

                if (usuarioExistente == null)
                    _dataset.Create(pUsuario);
                else
                    _dataset.Update(pUsuario);

                return true;
            }
            catch (Exception ex)
            {
                pCallbackErro.Invoke(ex.Message);
                return false;
            }
        }
        public List<Usuario> ObterUsuarios()
        {
            return _dataset.Read();
        }

        public Usuario ObterPeloNomeUsuario(string pNomeUsuario)
        {
            return _dataset.Read().FirstOrDefault(usuario => usuario.NomeUsuario.Equals(pNomeUsuario));
        }

        public void ExcluirUsuario(Usuario pUsuario)
        {
            _dataset.Delete(pUsuario);
        }

        private void Validar(Usuario pUsuario)
        {
            if (string.IsNullOrWhiteSpace(pUsuario.NomeUsuario))
                throw new System.Exception("Nome de usuário deve ser informado.");

            if (string.IsNullOrWhiteSpace(pUsuario.Senha))
                throw new System.Exception("Senha deve ser informada.");
        }
    }
}
