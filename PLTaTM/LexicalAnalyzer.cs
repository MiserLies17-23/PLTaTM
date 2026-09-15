namespace PLTaTM
{
    /// <summary>
    /// Класс лексического анализатора
    /// </summary>
    public class LexicalAnalyzer
    {
        /// <summary>
        /// Словарь ключевых слов
        /// </summary>
        private static readonly Dictionary<string, TokenType> Keywords = new()
        {
            ["var"] = TokenType.KeywordVar,
            ["logical"] = TokenType.KeywordLogical,
            ["begin"] = TokenType.KeywordBegin,
            ["end"] = TokenType.KeywordEnd,
        };

        /// <summary>
        /// Словарь операторов
        /// </summary>
        private static readonly Dictionary<string, TokenType> Operators = new()
        {
            ["="] = TokenType.Assign,
            [":"] = TokenType.Colon,
            [","] = TokenType.Comma,
            [";"] = TokenType.Semicolon,
            ["("] = TokenType.LParen,
            [")"] = TokenType.RParen,
        };

        /// <summary>
        /// Словарь бинарных операций
        /// </summary>
        private static readonly Dictionary<string, TokenType> BinOps = new()
        {
            [".and."] = TokenType.BinAnd,
            [".or."] = TokenType.BinOr,
            [".equ."] = TokenType.BinEqu,
        };

        /// <summary>
        /// Словарь унарных операций
        /// </summary>
        private static readonly Dictionary<string, TokenType> UnOps = new()
        {
            [".not."] = TokenType.UnNot,
        };

        /// <summary>
        /// Словарь констант
        /// </summary>
        private static readonly Dictionary<string, TokenType> Consts = new() 
        { 
            ["0"] = TokenType.ZeroConst,
            ["1"] = TokenType.OneConst,
        };

        /// <summary>
        /// Словарь пользовательских операций (соответствуют варианту)
        /// </summary>
        private static readonly Dictionary<string, TokenType> Operations = new()
        {
            ["repeat"] = TokenType.RepeatOp,
            ["until"] = TokenType.UntilOp,
            ["read"] = TokenType.ReadOp, 
            ["write"] = TokenType.WriteOp,
        };

        /// <summary>
        /// Метод для анализа каждой строки кода.
        /// Синтаксический анализатор принимает весь файл с кодом,
        /// а лексический анализитор посимвольно анализирует каждую строку.
        /// </summary>
        /// <param name="line"> Строка кода </param>
        /// <returns> Сообщение с распозннаными лексемами </returns>
        public List<Token> Analyze(string? line)
        {
            ArgumentNullException.ThrowIfNull(line);

            var tokens = new List<Token>();
            int i = 0;

            while (i < line.Length)
            {
                char c = line[i];

                if (char.IsWhiteSpace(c))
                {
                    i++;
                    continue;
                }

                if (char.IsLetter(c))
                {
                    int start = i;
                    while (i < line.Length && char.IsLetter(line[i]))
                        i++;

                    string text = line[start..i];
                    var type = Keywords.TryGetValue(text, out var kw)
                        ? kw 
                        : Operations.TryGetValue(text, out kw)
                            ? kw
                            : TokenType.Identifier;
                    tokens.Add(new Token(type, text, start));
                    continue;
                }

                if (char.IsDigit(c))
                {
                    int start = i;
                    while (i < line.Length && char.IsDigit(line[i]))
                        i++;

                    string text = line[start..i];
                    if (!Consts.TryGetValue(text, out var ct))
                        throw new Exception($"Неизвестная константа '{text}' в позиции {start}");

                    tokens.Add(new Token(ct, text, start));
                    continue;
                }

                if (c == '.')
                {
                    int start = i;
                    while (i < line.Length && char.IsLetter(c))
                        i++;

                    if (line[i + 1] != '.')
                        throw new Exception($"Операция не закрыта '.'");

                    string text = line[start..i++];
                    if (BinOps.TryGetValue(text, out var bOpType))
                    {
                        tokens.Add(new Token(bOpType, text, start));
                        continue;
                    }
                    if (UnOps.TryGetValue(text, out var uOpType))
                    {
                        tokens.Add(new Token(uOpType, text, start));
                        continue;
                    }
                    throw new Exception($"Неизвестная операция");                    
                }

                if (Operators.TryGetValue(c.ToString(), out var singleOp))
                {
                    tokens.Add(new Token(singleOp, c.ToString(), i));
                    i++;
                    continue;
                }

                throw new Exception($"Неизвестный символ '{c}' в позиции {i}");
            }

            return tokens;
        }
    } 
}
