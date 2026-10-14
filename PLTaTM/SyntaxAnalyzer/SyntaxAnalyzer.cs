using PLTaTM.Grammer;
using PLTaTM.Grammer.Symbols;

namespace PLTaTM.SyntaxAnalyzer
{
    public class SyntaxAnalyzer
    {
        private readonly ParserTable _table;
        private readonly List<Symbol> _stack = [];
        private IReadOnlyList<Token> _tokens = [];
        private int _pos;

        public SyntaxAnalyzer(ParserTable table) => _table = table;

        public bool Parse(IReadOnlyList<Token> tokens)
        {
            _tokens = tokens;
            _pos = 0;
            _stack.Clear();

            while (_pos < _tokens.Count)
            {
                var token = _tokens[_pos];
                var action = FindAction(token.Type);

                switch (action.Kind)
                {
                    case ActionKind.Shift:
                        Shift(token);
                        break;

                    case ActionKind.Reduce:
                        Reduce(action.RuleNumber);
                        break;

                    case ActionKind.Accept:
                        return true;
                }
            }
            return false;
        }

        // считывание
        private void Shift(Token token)
        {
            _stack.Add(Symbol.Of(token.Type));
            _pos++;
        }

        // свёртка
        private void Reduce(int ruleNumber)
        {
            var rule = _table.GetRule(ruleNumber);

            for (int i = 0; i < rule.RightLength; i++)
                _stack.RemoveAt(_stack.Count - 1);

            _stack.Add(Symbol.Of(rule.Left));
        }

        // Действия
        private ParserAction FindAction(TokenType token)
        {
            foreach (var rule in _table.Rules)
            {
                if (!_table.TryGetAction(rule.Number, token, out var action))
                    continue;
                if (!RhsMatches(rule))
                    continue;
                return action;
            }

            // Если ни одна свёртка не подошла — перенос
            return new ParserAction(ActionKind.Shift);
        }

        private bool RhsMatches(Rule rule)
        {
            if (_stack.Count < rule.RightLength) return false;

            int offset = _stack.Count - rule.RightLength;
            for (int i = 0; i < rule.RightLength; i++)
            {
                var want = rule.Right[i];
                var have = _stack[offset + i];

                if (want.Nt is { } nt)
                {
                    if (have.Nt != nt) return false;
                }
                else if (want.Tk is { } tk)
                {
                    if (have.Tk != tk) return false;
                }
            }
            return true;
        }
    }
}
