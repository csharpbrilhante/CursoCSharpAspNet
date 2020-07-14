using MeiosDeTransporte.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiosDeTransporte
{
    class Program
    {
        static void Main(string[] args)
        {
            var carro = new Veiculo();
            carro.Abastecer("Gasolina");
            Console.WriteLine($"Meu carro é movido agora a {carro.Combustivel}");
            carro.Abastecer("Alcool");
            Console.WriteLine($"Meu carro é movido agora a {carro.Combustivel}");
            Console.ReadKey();
        }
    }
}
