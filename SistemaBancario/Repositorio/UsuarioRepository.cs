using SistemaBancario.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario.Repositorio
{
    public class UsuarioRepository
    {
        // a instancia singleton
        private static UsuarioRepository _instancia;
        private static List<Usuario> _usuarios;

        UsuarioRepository()
        {
            _usuarios = new List<Usuario>()
            {
                //new Correntista(){Id = 1, Nome = "José da Silva", Ativo = true},
                //new Correntista(){Id = 2, Nome = "Maria da Silva", Ativo = true}
            };
        }

        public static UsuarioRepository ObterInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new UsuarioRepository();
            }

            return _instancia;
        }

        public void Create(Usuario pUsuario)
        {
            pUsuario.Id = _usuarios?.Count > 0 ? _usuarios.Max(x => x.Id) + 1 : 1;
            _usuarios.Add(pUsuario);
        }

        public List<Usuario> Read()
        {
            return _usuarios;
        }

        public void Update(Usuario pUsuario)
        {
            var usuarioCursor = _usuarios.FirstOrDefault(x => x.Id == pUsuario.Id);

            usuarioCursor.NomeUsuario = pUsuario.NomeUsuario;
            usuarioCursor.Senha = pUsuario.Senha;
        }

        public void Delete(Usuario pUsuario)
        {
            _usuarios.Remove(pUsuario);
        }
    }
}
