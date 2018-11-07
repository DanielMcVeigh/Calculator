using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LexerCalculator.ClassLibrary
{
    public class TokenParse
    {
        public int Parse(List<Token> tokenSequence)
        {
            // Deal with brackets first
            throw new NotImplementedException();

        }

        /// <summary>
        /// Finds the positions of the inner most bracket pair. 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="tokenString"></param>
        /// <returns></returns>
        public static BracketMatch FindBracketGroup(string tokenString)
        {
            Regex regex = new Regex(@"(\((?:\(??[^\(]*?\)))", RegexOptions.IgnoreCase);
            var match = regex.Match(tokenString);

            if (!match.Success)
                return new BracketMatch()
                {
                    IsMatch = false
                };

            var remainingText = string.Empty;
            if (match.Length != tokenString.Length)
            {
                remainingText = regex.Replace(tokenString, String.Empty);
            }
                
            return new BracketMatch()
            {
                IsMatch = true,
                MatchedGroup = match.Value,
                RemainingText = remainingText
            };

        }

    }
}
