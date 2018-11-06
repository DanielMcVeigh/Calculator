using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexerCalculator.ClassLibrary;

namespace LexerCalculator.ClassLibrary
{
    public class TokenBrackets
    {
        public int OpenBracketPos { get; set; }
        public int CloseBracketPos { get; set; }
        public List<Token> EnclosedTokenSequence { get; set; }
    }
}
