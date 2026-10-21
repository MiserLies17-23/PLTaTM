using PLTaTM.Errors;
using PLTaTM.Grammer.Symbols;

namespace PLTaTM.LexicalAnalyzer
{
    /// <summary>
    /// Класс лексического анализатора
    /// </summary>
    public class LexicalAnalyzer
    {
        /// <summary>
        /// Словарь ключевых слов
        /// </summary>
        private static readonly Dictionary<string, TokenType> Keywords = new(StringComparer.OrdinalIgnoreCase)
        {
            ["var"] = TokenType.KeywordVar,
            ["logical"] = TokenType.KeywordLogical,
            ["begin"] = TokenType.KeywordBegin,
            ["end"] = TokenType.KeywordEnd,
        };

        /// <summary>
        /// Словарь операторов
        /// </summary>
        private static readonly Dictionary<string, TokenType> Operators = new(StringComparer.OrdinalIgnoreCase)
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
        private static readonly Dictionary<string, TokenType> BinOps = new(StringComparer.OrdinalIgnoreCase)
        {
            [".and."] = TokenType.BinAnd,
            [".or."] = TokenType.BinOr,
            [".equ."] = TokenType.BinEqu,
        };

        /// <summary>
        /// Словарь унарных операций
        /// </summary>
        private static readonly Dictionary<string, TokenType> UnOps = new(StringComparer.OrdinalIgnoreCase)
        {
            [".not."] = TokenType.UnNot,
        };

        /// <summary>
        /// Словарь констант
        /// </summary>
        private static readonly Dictionary<string, TokenType> Consts = new(StringComparer.OrdinalIgnoreCase) 
        { 
            ["0"] = TokenType.ZeroConst,
            ["1"] = TokenType.OneConst,
        };

        /// <summary>
        /// Словарь пользовательских операций (соответствуют варианту)
        /// </summary>
        private static readonly Dictionary<string, TokenType> Operations = new(StringComparer.OrdinalIgnoreCase)
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
                        throw new LexicalException($"Лексическая ошибка: Неизвестная константа '{text}' в позиции {start}");

                    tokens.Add(new Token(ct, text, start));
                    continue;
                }

                if (c == '.')
                {
                    int start = i;
                    i++;

                    while (i < line.Length && char.IsLetter(line[i]))
                    {
                        i++;
                    }

                    if (i >= line.Length || line[i] != '.')
                    {
                        throw new LexicalException($"Лексическая ошибка: Операция не закрыта '.' в позиции {start}");
                    }

                    i++;
                    string text = line[start..i];

                    string lowerText = text.ToLowerInvariant();

                    if (BinOps.TryGetValue(lowerText, out var bOpType))
                    {
                        tokens.Add(new Token(bOpType, text, start));
                        continue;
                    }
                    if (UnOps.TryGetValue(lowerText, out var uOpType))
                    {
                        tokens.Add(new Token(uOpType, text, start));
                        continue;
                    }

                    throw new LexicalException($"Лексическая ошибка: Неизвестная операция '{text}' в позиции {start}");
                }

                if (Operators.TryGetValue(c.ToString(), out var singleOp))
                {
                    tokens.Add(new Token(singleOp, c.ToString(), i));
                    i++;
                    continue;
                }
                
                if (c == ':')
                {
                    i++;
                    continue;
                }

                if (Operators.TryGetValue(c.ToString(), out var single))
                {
                    tokens.Add(new Token(single, c.ToString(), i));
                    i++;
                    continue;
                }

                throw new LexicalException($"Лексическая ошибка: Неизвестный символ '{c}' в позиции {i}");
            }

            return tokens;
        }
    } 
}
