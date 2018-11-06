using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexerCalculator.ClassLibrary;
using static LexerCalculator.ClassLibrary.Enum;
using Enum = LexerCalculator.ClassLibrary.Enum;

namespace LexerCalculator.ClassLibrary
{
    public class Tokenizer
    {
        private List<TokenDefinition> _tokenDefinitions;

        public Tokenizer()
        {
            _tokenDefinitions = new List<TokenDefinition>();

            _tokenDefinitions.Add(new TokenDefinition(Enum.TokenType.Add, "^[+]"));
            _tokenDefinitions.Add(new TokenDefinition(Enum.TokenType.Subtract, "^[-]"));
            _tokenDefinitions.Add(new TokenDefinition(Enum.TokenType.Divide, "^[/]"));
            _tokenDefinitions.Add(new TokenDefinition(Enum.TokenType.Multiply, "^[*]"));
            _tokenDefinitions.Add(new TokenDefinition(Enum.TokenType.Power, @"^[\^]"));
            _tokenDefinitions.Add(new TokenDefinition(Enum.TokenType.BracketOpen, @"^[\(]"));
            _tokenDefinitions.Add(new TokenDefinition(Enum.TokenType.BracketClose, @"^[\)]"));
            _tokenDefinitions.Add(new TokenDefinition(Enum.TokenType.FloatValue, @"^([0-9]*\.[0-9]*)"));
            _tokenDefinitions.Add(new TokenDefinition(Enum.TokenType.IntegerValue, "^[0-9]+"));
        }



        public List<Token> Tokenize(string lqlText)
        {
            var tokens = new List<Token>();
            string remainingText = lqlText;

            while (!string.IsNullOrWhiteSpace(remainingText))
            {
                var match = FindMatch(remainingText);
                if (match.IsMatch)
                {
                    tokens.Add(new Token(match.TokenType, match.Value));
                    remainingText = match.RemainingText;
                }
                else
                {
                    remainingText = remainingText.Substring(1);
                }
            }

            tokens.Add(new Token(TokenType.NotDefined, string.Empty));

            return tokens;
        }

        private TokenMatch FindMatch(string lqlText)
        {
            foreach (var tokenDefinition in _tokenDefinitions)
            {
                var match = tokenDefinition.Match(lqlText);
                if (match.IsMatch)
                    return match;
            }

            return new TokenMatch() { IsMatch = false };
        }
    }
}
