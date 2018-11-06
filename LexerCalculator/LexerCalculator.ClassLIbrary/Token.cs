using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum = LexerCalculator.ClassLibrary.Enum;

namespace LexerCalculator.ClassLibrary
{
    public class Token
    {
        public Token(Enum.TokenType tokenType)
        {
            TokenType = tokenType;
            Value = string.Empty;
        }

        public Token(Enum.TokenType tokenType, string value)
        {
            TokenType = tokenType;
            Value = value;
        }

        public Token(object notDefined, string empty)
        {
        }

        public Enum.TokenType TokenType { get; set; }
        public string Value { get; set; }

        public Token Clone()
        {
            return new Token(TokenType, Value);
        }


    }
}
