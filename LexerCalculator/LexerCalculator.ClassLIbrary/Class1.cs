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
        /// BlockIn - Any opening block parameter such as '(' '{' '['.
        /// BlockOut - Any closing block parameter such as ')' ']' '}'.
        /// NumberValue - Any number which will be used. Either integers or floats. 
        /// </remarks>

        public enum TokenType
        {
            NotDefined,
            Operator,
            BlockIn,
            BlockOut,
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


        public static Enum.TokenType DefineTokenType(string checkCharacter)
        {
            // Regex definitions
            Regex operatorRegex = new Regex(@"[+^*/=-]");
            Regex numberValueRegex = new Regex(@"[0-9]");
            Regex blockInRegex = new Regex(@"[\(\{\[]");
            Regex blockOutRegex = new Regex(@"[\)\}\]]");

            if (operatorRegex.IsMatch(checkCharacter))
            {
                return Enum.TokenType.Operator;
            }

            if (numberValueRegex.IsMatch(checkCharacter))
            {
                return Enum.TokenType.NumberValue;
            }
            if (blockInRegex.IsMatch(checkCharacter))
            {
                return Enum.TokenType.BlockIn;
            }
            if (blockOutRegex.IsMatch(checkCharacter))
            {
                return Enum.TokenType.BlockOut;
            }
            throw new ArgumentException();
        }

        /// <summary>
        /// Removes all illegal characters from the string parameter using regular expressions.
        /// </summary>
        /// <param name="stringInput"> A string input from the user</param>
        /// <returns>String with all illegal characters removed</returns>
        public static string SanitizeString(string stringInput)
        {
            string stringOutput;

            // Remove whitespace
            stringOutput = Regex.Replace(stringInput, @"\s+", "");

            // Removes unexpected symbols
            stringOutput = Regex.Replace(stringInput, @"[^a-z^A-Z^0-9+-\/*^(){}\[\]]", "");

            return stringOutput;
        }

        /// <summary>
        /// Separates string into a list containing the string of each character.
        /// </summary>
        /// <param name="stringInput"></param>
        /// <returns>List of strings</returns>
        public static List<string> SeparateCharacters(string stringInput)
        { 
            var charArrayInput = stringInput.ToCharArray();
            List<string> output = new List<string>();

            foreach (char c in charArrayInput)
            {
                output.Add(c.ToString());
            }

            return output;
        }
    }
}