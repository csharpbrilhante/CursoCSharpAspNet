using SistemaBancario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Repositorio
{
    public class DBMem
    {
        private static readonly List<Correntista> _correntistas;
        private static readonly List<Usuario> _usuarios;

        static DBMem()
        {
            _correntistas = new List<Correntista>();
            _usuarios = new List<Usuario>();
        }

        public static List<Correntista> ObterCorrentistas()
        {
            return _correntistas;
        }

        public static List<Usuario> ObterUsuarios()
        {
            return _usuarios;
        }
    }
}
