using Animais.Contratos;
using Animais.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animais
{
    class Program
    {
        static void Main(string[] args)
        {
            var animais = new List<IAnimal>();

            var cachorro = new Cachorro();

            animais.Add(cachorro);
            animais.Add(new Gato());
            
            animais.Add(new Golfinho());
            
            animais.Add(new Morcego());
            animais.Add(new Pardal());
            
            animais.Add(new Pato());
            animais.Add(new Peixe());

            var inventarioDoAnimal =
@"Animal: {0}, 
O Som que ele emite: {1},
O animal voa: {2},
O animal nada: {3},
O animal é um mamífero: {4},
O animal tem penas: {5}";

            foreach (var animal in animais)
            {
                try
                {
                    Console.WriteLine(
                                string.Format(inventarioDoAnimal, 
                                              animal.Nome, 
                                              animal.EmitirSom(),
                                              (animal is IAnimalVoador ? (animal as IAnimalVoador).Voar() : false),
                                              (animal is IAnimalNadador ? (animal as IAnimalNadador).Nadar() : false),
                                              (animal is IMamifero ? (animal as IMamifero).Mamar() : false),
                                              (animal is IAve ? (animal as IAve).PossuiPenas() : false))
                            );
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro no animal {animal.Nome}, detalhe: {ex.Message}");
                }
            }

            Console.ReadKey();
        }
    }
}
