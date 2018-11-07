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
            Console.WriteLine("Input the expression to be parsed: ");
            var inputString = Console.ReadLine();
            var match = TokenParse.FindBracketGroup(inputString);

            Console.WriteLine("Input: {0}", inputString);
            Console.WriteLine("Bracket Group: {0}", match.MatchedGroup);
            Console.WriteLine("Remaining Text: {0}", match.RemainingText);


            Console.ReadKey();

        }
    }
}
