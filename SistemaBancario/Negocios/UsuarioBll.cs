using SistemaBancario.Modelos;
using SistemaBancario.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario.Negocios
{
    public class UsuarioBll
    {
        private readonly UsuarioRepository _dataset = new UsuarioRepository();

        public void CriarOuAtualizarUsuario(Usuario pUsuario, Action<string> pCallback)
        {
            try
            {
                Validar(pUsuario);
            }
            catch (Exception ex)
            {
                pCallback.Invoke(ex.Message);
            }

            var usuarioExistente = _dataset.Read().FirstOrDefault(x => x.Id == pUsuario.Id);

            if (usuarioExistente == null)
                _dataset.Create(pUsuario);
            else
                _dataset.Update(pUsuario);
        }
        public List<Usuario> ObterUsuarios()
        {
            return _dataset.Read();
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
