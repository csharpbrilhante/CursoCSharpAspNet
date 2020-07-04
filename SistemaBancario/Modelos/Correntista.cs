using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Modelos
{
    public class Correntista
    {
        public int Id { get; set; } //primary key
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public bool Ativo { get; set; }
    }
}
