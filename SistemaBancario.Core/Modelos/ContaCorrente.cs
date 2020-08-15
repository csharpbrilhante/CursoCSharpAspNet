using SistemaBancario.Core.Contratos;
using System;

namespace SistemaBancario.Core.Modelos
{
    public class ContaCorrente : IModelo
    {
        public int Id { get; set; }
        public string Agencia { get; set; }
        public string NumConta { get; set; }        
        public int CorrentistaId { get; set; }
        public Correntista Correntista { get; set; }
        //public Lazy<Correntista> MyProperty { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
