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
        /// 
        /// <remarks>
        /// NotDefined - Any item which the lexer cannot identify will be assigned value 0.
        /// Operator - Operation symbols such as '*' '+' '-' '/'.
        /// Block - Any item which requires a partner. Such as '(' which requires ')'.
        /// NumberValue - Any number which will be used. Either integers or floats. 
        /// </remarks>

        public enum TokenType
        {
            NotDefined,
            Operator,
            Block,
            NumberValue
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

        /// <summary>
        /// Token type.
        /// </summary>
        /// <value>
        /// Return variable for the TokenType.
        /// </value>
        /// <seealso cref="Enum.TokenType"/>
        private readonly Enum.TokenType _returnsToken;


        public struct Token
        {
            public Token(int type, int startIndex, int length, object value = null)
            {
                Type = type;
                StartIndex = startIndex
            }
     }
        {
            
        }
        }
    }
}
