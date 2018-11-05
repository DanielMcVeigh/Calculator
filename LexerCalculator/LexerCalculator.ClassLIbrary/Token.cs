using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum = LexerCalculator.ClassLibrary.Enum;

namespace LexerCalculator.ClassLIbrary
{
    public class Token
    {
        public Enum.TokenType TokenType { get; set; }
        public string Value { get; set; }
        
    }
}
