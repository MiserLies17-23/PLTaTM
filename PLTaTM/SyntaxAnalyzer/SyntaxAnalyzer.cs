using PLTaTM.Exceptions;
using PLTaTM.Grammer;
using PLTaTM.Grammer.Symbols;

namespace PLTaTM.SyntaxAnalyzer
{
    public class SyntaxAnalyzer
    {
        private readonly ParserTable _table;
        private readonly List<Symbol> _stack = [];
        private readonly List<int> _stateStack = [];
        private IReadOnlyList<Token> _tokens = [];
        private int _pos;

        public SyntaxAnalyzer(ParserTable table) => _table = table;

        public bool Parse(IReadOnlyList<Token> tokens)
        {
            _tokens = tokens;
            _pos = 0;
            _stack.Clear();
            _stateStack.Clear();
            
            _stateStack.Add(0); // Начальное состояние

            while (true)
            {
                int currentState = _stateStack[^1];
                var currentTokenType = _pos < _tokens.Count ? _tokens[_pos].Type : TokenType.Eof;

                if (!_table.Action.TryGetValue((currentState, currentTokenType), out var action))
                {
                    string errorMsg;
                    if (_pos < _tokens.Count)
                    {
                        var badToken = _tokens[_pos];
                        errorMsg = $"Синтаксическая ошибка: неожиданный токен '{badToken.Value}' (тип: {badToken.Type}) на позиции {badToken.Position}.";
                    }
                    else
                    {
                        errorMsg = "Синтаксическая ошибка: неожиданный конец файла (Eof).";
                    }

                    throw new SyntaxException(errorMsg);
                }

                if (action.Kind == ActionKind.Accept)
                    return true;

                if (action.Kind == ActionKind.Shift)
                {
                    Shift(_tokens[_pos], action.RuleNumber); 
                    _pos++;
                }
                else if (action.Kind == ActionKind.Reduce)
                {
                    Reduce(action.RuleNumber);                 }
            }
        }

        // считывание
        private void Shift(Token token, int nextState)
        {
            _stack.Add(Symbol.Of(token.Type));
            _stateStack.Add(nextState); 
        }

        // свёртка
        private void Reduce(int ruleNumber)
        {
            var rule = _table.GetRule(ruleNumber);

            for (int i = 0; i < rule.RightLength; i++)
            {
                _stack.RemoveAt(_stack.Count - 1);
                _stateStack.RemoveAt(_stateStack.Count - 1);
            }

            _stack.Add(Symbol.Of(rule.Left));

            int newTopState = _stateStack[^1];
            int nextState = _table.Goto[(newTopState, rule.Left)];

            _stateStack.Add(nextState);
        }
    }
}
