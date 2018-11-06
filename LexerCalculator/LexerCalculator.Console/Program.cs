using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexerCalculator.ClassLibrary;

namespace LexerCalculator.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenizer = new Tokenizer();
            Console.WriteLine("Input a query to tokenize: ");
            var query = Console.ReadLine();
            Console.WriteLine(query);
            var tokenSequence = tokenizer.Tokenize(query).ToList();
            foreach (var token in tokenSequence)
            {
                Console.WriteLine("TokenType: {0}, Value: {1}", token.TokenType, token.Value);
            }


            Console.ReadKey();

        }
    }
}
