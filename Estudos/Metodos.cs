using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos
{
    public class Metodos
    {
        /// <summary>
        /// Método Executar
        /// {visibilidade} {retorno} {nome} () { }
        /// </summary>
        public void Executar()
        {
            Console.WriteLine("Método executado");
        }

        /// <summary>
        /// Método com Parâmetro
        /// </summary>
        /// <param name="pTexto">O texto a receber</param>
        public void ExecutarComParametro(string pTexto)
        {
            Console.WriteLine(pTexto);
        }

        public void Somar(int pNumero1, int pNumero2)
        {
            int soma = pNumero1 + pNumero2;
            Console.WriteLine($"A soma = {soma}");
        }

        public void SomarComDefault(int pNumero1, int pNumero2, string pTexto = "default", int pNumero3 = 0)
        {
            int soma = pNumero1 + pNumero2 + pNumero3;
            Console.WriteLine($"A soma com {pTexto} = {soma}");
        }

        /// <summary>
        /// Método que retorna se um número é par
        /// </summary>
        /// <param name="pNumero">O npumero a ser testado</param>
        /// <returns>Se é par</returns>
        public bool NumeroPar(int pNumero)
        {
            return pNumero % 2 == 0;
        }

        public int ObterSoma(int pNumero1, int pNumero2)
        {
            var soma = pNumero1 + pNumero2;
            return soma;
        }

        public void SomarValorPorReferencia(int pNumero1, int pNumero2, ref int pSoma)
        {
            pSoma += pNumero1 + pNumero2;
        }
    }
}
