namespace PLTaTM.Errors
{
    public class LexicalException : Exception
    {
        private string _lexem;

        public LexicalException(string? message) : base(message)
        {
            _lexem = "";
        }

        public LexicalException(string message, string lexem) : base(message)
        {
            _lexem = lexem;
        }

        public override string ToString()
        {
            return $"{Message}\nЛексема {_lexem} не распознана!";
        }
    }
}
