namespace LexerCalculator.ClassLibrary
{
    public class TokenMatch
    {
        public bool IsMatch { get; set; }
        public Enum.TokenType TokenType { get; set; }
        public string Value { get; set; }
        public string RemainingText { get; set; }
    }
}
