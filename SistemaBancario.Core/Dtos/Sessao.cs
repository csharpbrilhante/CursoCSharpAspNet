using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Core.Dtos
{
    public class Sessao
    {
        public string Agencia { get; set; }
        public string NumeroConta { get; set; }
        public string NomeCorrentista { get; set; }
    }
}
