using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Contratos
{
    public interface IModelo
    {
        int Id { get; set; }
        DateTime DataCriacao { get; set; }
    }
}
