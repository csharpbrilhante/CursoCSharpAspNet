using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos
{
    public class Condicional
    {
        bool _valorA = false;
        bool _valorB = true;
        bool _valorC = true;

        public void TestarAnd()
        {
            Console.WriteLine($"{_valorA} E {_valorB} = {(_valorA && _valorB ? "Verdadeiro" : "falso")}");
            if(_valorA && _valorB)
            {
                Console.WriteLine("Verdadeiro");
            }
            else
            {
                Console.WriteLine("Falso");
            }
        }

        public void TestarOr()
        {
            //Console.WriteLine($"{_valorA} OU ({_valorB} E {_valorC})  = {(_valorA || (_valorB && _valorC) ? "Verdadeiro" : "falso")}");

            if (!(! _valorA))
            {
                Console.WriteLine("Verdadeiro");
            }
            else
            {
                Console.WriteLine("Falso");
            }
        }

        public void TestarWhile()
        {
            var do_work = true;
            var numero = 0;
            
            while (do_work)
            {
                numero++;
                Console.WriteLine($"Número é {numero}");

                if (numero >= 10)
                    do_work = false;
            }
        }




        public void RetornarDescricaoEstadoCivil(EstadoCivil pMeuEstado)
        {
            var resultado = "";

            switch (pMeuEstado)
            {
                case EstadoCivil.Solteiro: resultado = "Solteiro"; break;
                case EstadoCivil.Casado: resultado = "Casado"; break;
                case EstadoCivil.Divorciado: resultado = "Divorciado"; break;
                case EstadoCivil.Viuvo: resultado = "Viúvo"; break;
                default: resultado = "Não consta"; break;
            }

            Console.WriteLine(resultado);

        }
    }

    public enum EstadoCivil
    {
        Solteiro = 0,
        Casado = 1,
        Divorciado = 2, 
        Viuvo = 3
    }
}
