using SistemaBancario.Contratos;
using System;

namespace SistemaBancario.Modelos
{
    public class Correntista: IModelo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
