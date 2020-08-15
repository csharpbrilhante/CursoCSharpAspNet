using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.CaixaEletronico.Interfaces
{
    public delegate void AoFecharPagina();
    
    public interface IPagina
    {
        event AoFecharPagina Fechar;
    }
}
