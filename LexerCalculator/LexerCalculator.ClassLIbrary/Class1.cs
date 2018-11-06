using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LexerCalculator.ClassLibrary
{
    /// <summary>
    /// Defines TokenType values for use when using lexer on strings.
    /// </summary>
    /// <seealso cref="System.Enum"/>
    public class Enum
    {
        /// <summary>
        /// Defines the TokenType values.
        /// </summary>

        public enum TokenType
        {
            NotDefined,
            Add,
            Subtract,
            Divide,
            Multiply,
            IntegerValue,
            FloatValue,
            BracketOpen,
            BracketClose,
            Power
        }
    }

    /// <summary>
    /// Identifies TokenTypes.
    /// </summary>
    /// <seealso cref="Enum.TokenType"/>

    public class TokenDefinition
    {
        /// <summary>
        /// Regex property.
        /// </summary>
        /// <value>
        /// Stores the Regex pattern to match.
        /// </value>
        private Regex _regex;

        private readonly Enum.TokenType _returnsToken;
            
        public TokenDefinition(Enum.TokenType returnsToken, string regexPattern)
        {
            _regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            _returnsToken = returnsToken;
        }

        public TokenMatch Match(string inputString)
        {
            var match = _regex.Match(inputString);
            if (match.Success)
            {
                string remainingText = string.Empty;
                if (match.Length != inputString.Length)
                    remainingText = inputString.Substring(match.Length);

                return new TokenMatch()
                {
                    IsMatch = true,
                    RemainingText = remainingText,
                    TokenType = _returnsToken,
                    Value = match.Value
                };
            }
            else
            {
                return new TokenMatch() {IsMatch = false};
            }
        }
    }
}