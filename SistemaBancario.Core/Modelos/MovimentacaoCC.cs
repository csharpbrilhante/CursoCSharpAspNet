using SistemaBancario.Core.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Core.Modelos
{
    public class MovimentacaoCC: IModelo
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public int ContaCorrenteId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string Historico { get; set; }
    }
}
