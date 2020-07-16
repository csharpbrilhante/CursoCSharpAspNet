using SistemaBancario.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario.Repositorio
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public override void Update(Usuario pObjeto)
        {
            var usuarioAtualizar = lista.FirstOrDefault(x => x.Id == pObjeto.Id);
            usuarioAtualizar.NomeUsuario = pObjeto.NomeUsuario;
            usuarioAtualizar.Senha = pObjeto.Senha;
        }
    }
}
