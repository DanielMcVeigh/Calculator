using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerCalculator.ClassLibrary
{
    class TokenParse
    {
        public int Parse(List<Token> tokenSequence)
        {
            // Deal with brackets first

            for (int i = 0; i < tokenSequence.Count; i++)
            {
                if (tokenSequence[i].TokenType == Enum.TokenType.BracketOpen)
                {
                    for (int j = i+1; j < tokenSequence.Count; j++)
                    {
                        if (tokenSequence[j].TokenType == Enum.TokenType.BracketOpen)
                        {
                            
                        }


                    }
                }
            }
            
            


            for (int i = 0; i < tokenSequence.Count; i++)
            {
                switch (tokenSequence[i].TokenType)
                {
                    case Enum.TokenType.Add:
                        

                        break;
                }

            }
        }

        private float AddValues(Token prevToken, Token nextToken)
        {

        }
    }
}
