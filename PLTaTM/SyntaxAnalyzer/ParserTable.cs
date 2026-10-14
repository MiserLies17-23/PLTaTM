using PLTaTM.Grammer;
using PLTaTM.Grammer.Symbols;

namespace PLTaTM.SyntaxAnalyzer
{
    public enum ActionKind 
    { 
        Shift, 
        Reduce, 
        Accept, 
        Error 
    }

    public record ParserAction(ActionKind Kind, int RuleNumber = 0);

    public sealed class ParserTable
    {
        public required IReadOnlyList<Rule> Rules { get; init; }
        public required IReadOnlyDictionary<(int Rule, TokenType Token), ParserAction> Action { get; init; }
        public Rule GetRule(int number) => Rules[number];
        public bool TryGetAction(int rule, TokenType token, out ParserAction action)
            => Action.TryGetValue((rule, token), out action!);
    }
}
