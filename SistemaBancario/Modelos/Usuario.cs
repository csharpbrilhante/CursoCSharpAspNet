using SistemaBancario.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Modelos
{
    public class Usuario: IModelo
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
