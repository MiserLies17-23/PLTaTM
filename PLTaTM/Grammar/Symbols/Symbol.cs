namespace PLTaTM.Grammer.Symbols
{
    public readonly record struct Symbol(NonTerminal? Nt, TokenType? Tk)
    {
        public static Symbol Of(NonTerminal nt) => new(nt, null);
        public static Symbol Of(TokenType tk) => new(null, tk);
    }

    public enum NonTerminal
    {
        I,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        G1,
        G2,
        G3,
        K,
        M,
        N
    }
}
