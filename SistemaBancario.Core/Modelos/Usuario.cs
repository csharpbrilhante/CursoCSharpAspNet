using SistemaBancario.Core.Contratos;
using System;

namespace SistemaBancario.Core.Modelos
{
    public class Usuario: IModelo
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
