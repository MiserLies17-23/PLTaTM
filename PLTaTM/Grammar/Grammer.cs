using PLTaTM.Grammer.Symbols;

namespace PLTaTM.Grammer
{
    public sealed record Rule(int Number, NonTerminal Left, IReadOnlyList<Symbol> Right)
    {
        public int RightLength => Right.Count;
    }

    public static class Grammar
    {
        public static IReadOnlyList<Rule> Rules { get; } = new Rule[]
        {
            //// 0: I -> A B
            //new(0, NonTerminal.I, new[]
            //{
            //    Symbol.Of(NonTerminal.A),
            //    Symbol.Of(NonTerminal.B),
            //}),

            //// 1: B -> Begin C End
            //new(1, NonTerminal.B, new[]
            //{
            //    Symbol.Of(TokenType.KeywordBegin),
            //    Symbol.Of(NonTerminal.C),
            //    Symbol.Of(TokenType.KeywordEnd),
            //}),

            //// 2: A -> var D :Logical ;
            //new(2, NonTerminal.A, new[]
            //{
            //    Symbol.Of(TokenType.KeywordVar),
            //    Symbol.Of(NonTerminal.D),
            //    Symbol.Of(TokenType.KeywordLogical),
            //    Symbol.Of(TokenType.Semicolon),
            //}),

            //// 3: D -> E
            //new(3, NonTerminal.D, new[]
            //{
            //    Symbol.Of(NonTerminal.E),
            //}),

            //// 4: D -> E , D
            //new(4, NonTerminal.D, new[]
            //{
            //    Symbol.Of(NonTerminal.E),
            //    Symbol.Of(TokenType.Comma),
            //    Symbol.Of(NonTerminal.D),
            //}),

            //// 5: C -> F
            //new(5, NonTerminal.C, new[]
            //{
            //    Symbol.Of(NonTerminal.F),
            //}),

            //// 6: C -> F , C
            //new(6, NonTerminal.C, new[]
            //{
            //    Symbol.Of(NonTerminal.F),
            //    Symbol.Of(TokenType.Comma),
            //    Symbol.Of(NonTerminal.C),
            //}),

            //// 7: G -> .Not. G
            //new(7, NonTerminal.G, new[]
            //{
            //    Symbol.Of(TokenType.UnNot),
            //    Symbol.Of(NonTerminal.G),
            //}),

            //// 8: G -> K
            //new(8, NonTerminal.G, new[]
            //{
            //    Symbol.Of(NonTerminal.K),
            //}),

            //// 9: G -> E
            //new(9, NonTerminal.G, new[]
            //{
            //    Symbol.Of(NonTerminal.E),
            //}),

            //// 10: G -> ( G1 )
            //new(10, NonTerminal.G, new[]
            //{
            //    Symbol.Of(TokenType.LParen),
            //    Symbol.Of(NonTerminal.G1),
            //    Symbol.Of(TokenType.RParen),
            //}),

            //// 11: G1 -> G1 .and. G2
            //new(11, NonTerminal.G1, new[]
            //{
            //    Symbol.Of(NonTerminal.G1),
            //    Symbol.Of(TokenType.BinAnd),
            //    Symbol.Of(NonTerminal.G2),
            //}),

            //// 12: G1 -> G2
            //new(12, NonTerminal.G1, new[]
            //{
            //    Symbol.Of(NonTerminal.G2),
            //}),

            //// 13: G2 -> G2 .or. G3
            //new(13, NonTerminal.G2, new[]
            //{
            //    Symbol.Of(NonTerminal.G2),
            //    Symbol.Of(TokenType.BinOr),
            //    Symbol.Of(NonTerminal.G3),
            //}),

            //// 14: G2 -> G3
            //new(14, NonTerminal.G2, new[]
            //{
            //    Symbol.Of(NonTerminal.G3),
            //}),

            //// 15: G3 -> G3 .equ. G
            //new(15, NonTerminal.G3, new[]
            //{
            //    Symbol.Of(NonTerminal.G3),
            //    Symbol.Of(TokenType.BinEqu),
            //    Symbol.Of(NonTerminal.G),
            //}),

            //// 16: G3 -> G
            //new(16, NonTerminal.G3, new[]
            //{
            //    Symbol.Of(NonTerminal.G),
            //}),

            //// 17: K -> E
            //new(17, NonTerminal.K, new[]
            //{
            //    Symbol.Of(NonTerminal.E),
            //}),

            //// 18: K -> M
            //new(18, NonTerminal.K, new[]
            //{
            //    Symbol.Of(NonTerminal.M),
            //}),

            //// 19: E -> N
            //new(19, NonTerminal.E, new[]
            //{
            //    Symbol.Of(NonTerminal.N),
            //}),

            //// 20: E -> N E
            //new(20, NonTerminal.E, new[]
            //{
            //    Symbol.Of(NonTerminal.N),
            //    Symbol.Of(NonTerminal.E),
            //}),

            //// 21: N -> letter
            //new(21, NonTerminal.N, new[]
            //{
            //    Symbol.Of(TokenType.Identifier),
            //}),

            //// 22: M -> 0
            //new(22, NonTerminal.M, new[]
            //{
            //    Symbol.Of(TokenType.ZeroConst),
            //}),

            //// 23: M -> 1
            //new(23, NonTerminal.M, new[]
            //{
            //    Symbol.Of(TokenType.OneConst),
            //}),

            //// 24: F -> read ( D ) ;
            //new(24, NonTerminal.F, new[]
            //{
            //    Symbol.Of(TokenType.ReadOp),
            //    Symbol.Of(TokenType.LParen),
            //    Symbol.Of(NonTerminal.D),
            //    Symbol.Of(TokenType.RParen),
            //    Symbol.Of(TokenType.Semicolon),
            //}),

            //// 25: F -> repeat C until G ;
            //new(25, NonTerminal.F, new[]
            //{
            //    Symbol.Of(TokenType.RepeatOp),
            //    Symbol.Of(NonTerminal.C),
            //    Symbol.Of(TokenType.UntilOp),
            //    Symbol.Of(NonTerminal.G),
            //    Symbol.Of(TokenType.Semicolon),
            //}),

            //// 26: F -> write ( D ) ;
            //new(26, NonTerminal.F, new[]
            //{
            //    Symbol.Of(TokenType.WriteOp),
            //    Symbol.Of(TokenType.LParen),
            //    Symbol.Of(NonTerminal.D),
            //    Symbol.Of(TokenType.RParen),
            //    Symbol.Of(TokenType.Semicolon),
            //}),
        };
    }
}