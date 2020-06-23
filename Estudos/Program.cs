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
            //atribuição
            string nome = "Meu nome"; //uma só igualdade é atribuição

            int numero1 = 1;
            int numero2 = 1;

            string resultado = "";

            if(numero1 >= numero2)
            {
                resultado = "é maior";
            }
            else
            {
                resultado = "não é maior";
            }

            Console.WriteLine(resultado);
            Console.ReadKey();
        }
    }
}
