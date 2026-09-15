namespace PLTaTM
{
    /// <summary>
    /// Перечисление зарезрвированных системой символов
    /// </summary>
    public enum TokenType
    {
        Identifier,
        KeywordVar,
        KeywordLogical,
        KeywordBegin,
        KeywordEnd,
        Assign,
        LParen,
        RParen,
        Colon,
        Comma,
        Semicolon,
        BinAnd,
        BinOr,
        BinEqu,
        UnNot,
        RepeatOp,
        UntilOp,
        ReadOp,
        WriteOp,
        ZeroConst,
        OneConst
    }

    /// <summary>
    /// Класс, представляющий токен.
    /// Содержит тип символа, значение и позицию в строке
    /// </summary>
    public class Token
    {
        public TokenType Type;
        public string? Value;
        public int Position;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="type"> Тип символа </param>
        /// <param name="value"> Значение </param>
        /// <param name="position"> Позиция в строке </param>
        public Token (TokenType type, string? value, int position)
        {
            Type = type;
            Value = value;
            Position = position;
        }
    }
}
