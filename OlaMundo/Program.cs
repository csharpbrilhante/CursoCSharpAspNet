using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlaMundo
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = new Random().Next(0, 999999);
            Console.WriteLine(num);
            Console.ReadKey();
        }
    }
}
