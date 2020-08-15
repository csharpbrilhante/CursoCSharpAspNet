using System;

namespace SistemaBancario.Core.Contratos
{
    public interface IModelo
    {
        int Id { get; set; }
        DateTime DataCriacao { get; set; }
    }
}
