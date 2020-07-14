using MeiosDeTransporte.Abstracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiosDeTransporte.Implementacao
{
    class Veiculo : ICarro
    {
        string _combustivel;

        public string Combustivel => _combustivel;

        /// <summary>
        /// Método que altera o combustível do nosso veículo
        /// </summary>
        /// <param name="pCombustivel"></param>
        public void Abastecer(string pCombustivel)
        {
            _combustivel = pCombustivel;
        }
    }
}
