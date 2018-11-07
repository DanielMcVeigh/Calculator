using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerCalculator.ClassLibrary
{
    public class BracketMatch
    {
        public bool IsMatch { get; set; }
        public string MatchedGroup { get; set; }
        public string RemainingText { get; set; }
    }
}
