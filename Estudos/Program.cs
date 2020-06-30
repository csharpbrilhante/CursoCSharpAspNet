using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos
{
    class Program
    {
        static void Main(string[] args)
        {
            var condicional = new Condicional();
            condicional.TestarWhile();
            Console.ReadKey();

            return; //aqui ele quebra o fluxo de execução!

            //tipo  variavel    operador de instanciacao/ associacao
            Metodos instancia = new Metodos();
            instancia.Executar();
            instancia.ExecutarComParametro("Olá mundo");

            int numero1 = 10;
            int numero2 = 10;

            instancia.Somar(numero1, numero2);

            int numero3 = 10;

            instancia.SomarComDefault(numero1, numero2);

            var numero_E_Par = instancia.NumeroPar(numero1);

            Console.WriteLine(string.Format("O número {0} é {1}", numero1, (numero_E_Par ? "Par" : "Ímpar"))); //usando format

            //Console.WriteLine($"O número {numero1} é {(numero_E_Par ? "Par" : "Ímpar")}"); //usando interpolação

            //Console.WriteLine("O número " + numero1 + " é " + (numero_E_Par ? "Par" : "Ímpar")); //conactenação simples

            Console.WriteLine(string.Concat("Método ObterSoma = ", instancia.ObterSoma(numero1, numero2)));

            int valor = 10;

            instancia.SomarValorPorReferencia(numero1, numero2, ref valor);

            Console.WriteLine($"O Valor = {valor}");

            Pessoa pessoa = new Pessoa("José", "Silva");
            Console.WriteLine($"O nome da pessoa é \"{pessoa.NomeCompleto}\"");
            Console.ReadKey();
        }
    }
}
