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
            _correntistas = new List<Correntista>()
            {
                new Correntista()
                {
                    Nome = "Daniel Junior",
                    CpfCnpj = "99999999999",
                    Ativo = true
                },
                new Correntista()
                {
                    Nome = "Danilo Ferreira",
                    CpfCnpj = "22222222222",
                    Ativo = false
                },
                new Correntista()
                {
                    Nome = "Mariana Trindade",
                    CpfCnpj = "88888888888",
                    Ativo = true
                },
                new Correntista()
                {
                    Nome = "Joao Pedro",
                    CpfCnpj = "77777777777",
                    Ativo = false
                },
                new Correntista()
                {
                    Nome = "Maria Clara",
                    CpfCnpj = "44444444444",
                    Ativo = true
                },
            };

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
