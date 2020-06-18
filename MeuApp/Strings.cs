using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuApp
{
    class Strings
    {
        public void EscreverTexto()
        {
            string mensagem = "Minha Mensagem";
            string mensagemNula = null;
            string mensagemVazia = string.Empty;
            string caminhoDeArquivoComEscape = "c:\\Program Files\nMicrosoft Visual Studio 8.0";
            string caminhoComLiterals = @"c:\Program Files\Microsoft Visual Studio 9.0";
            
            char[] letras = { 'M', 'A', 'Ç', 'A' };
            
            string novaPalavra = new string(letras);

            string nome = "Pedro";
            string sobrenome = "Silva";

            var nomeCompleto = string.Concat(nome, " ", sobrenome);

            //comentário: abaixo, temos um erro de designtime (não vai compilar)

            var textoParaConsole = nomeCompleto;
            Console.WriteLine(textoParaConsole);

        }
    }
}
