using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlaMundo2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool execute = true;
            int numero = 0;

            while (execute)
            {
                Console.WriteLine(numero);
                numero++;

                if(numero > 9)
                {
                    execute = false;
                }
            }

            Console.ReadKey();
        }
    }
}
