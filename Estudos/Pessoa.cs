using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos
{
    public class Pessoa
    {
		public Pessoa() { }

		public Pessoa(string pNome, string pSobreNome)
		{
			Nome = pNome;
			Sobrenome = pSobreNome;
		}

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string NomeCompleto  => Nome + " " + Sobrenome;


	}
}
