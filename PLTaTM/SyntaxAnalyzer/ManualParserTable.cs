using PLTaTM.Grammer;
using PLTaTM.Grammer.Symbols;

namespace PLTaTM.SyntaxAnalyzer
{
    public static class ManualParserTable
    {
        public static ParserTable Create()
        {
            var rules = new Rule[]
            {
                new(0,  NonTerminal.I,  new[] { Symbol.Of(NonTerminal.A), Symbol.Of(NonTerminal.B) }),
                new(1,  NonTerminal.A,  new[] { Symbol.Of(TokenType.KeywordVar), Symbol.Of(NonTerminal.D), Symbol.Of(TokenType.Colon), Symbol.Of(TokenType.KeywordLogical), Symbol.Of(TokenType.Semicolon) }),
                new(2,  NonTerminal.B,  new[] { Symbol.Of(TokenType.KeywordBegin), Symbol.Of(NonTerminal.C), Symbol.Of(TokenType.KeywordEnd) }),
                new(3,  NonTerminal.D,  new[] { Symbol.Of(NonTerminal.E) }),
                new(4,  NonTerminal.D,  new[] { Symbol.Of(NonTerminal.D), Symbol.Of(TokenType.Comma), Symbol.Of(NonTerminal.E) }),
                new(5,  NonTerminal.C,  new[] { Symbol.Of(NonTerminal.F) }),
                new(6,  NonTerminal.C,  new[] { Symbol.Of(NonTerminal.C), Symbol.Of(NonTerminal.F) }),
                new(7,  NonTerminal.F,  new[] { Symbol.Of(NonTerminal.E), Symbol.Of(TokenType.Assign), Symbol.Of(NonTerminal.G), Symbol.Of(TokenType.Semicolon) }),
                new(8,  NonTerminal.F,  new[] { Symbol.Of(TokenType.ReadOp), Symbol.Of(TokenType.LParen), Symbol.Of(NonTerminal.D), Symbol.Of(TokenType.RParen), Symbol.Of(TokenType.Semicolon) }),
                new(9,  NonTerminal.F,  new[] { Symbol.Of(TokenType.WriteOp), Symbol.Of(TokenType.LParen), Symbol.Of(NonTerminal.D), Symbol.Of(TokenType.RParen), Symbol.Of(TokenType.Semicolon) }),
                new(10, NonTerminal.F,  new[] { Symbol.Of(TokenType.RepeatOp), Symbol.Of(NonTerminal.C), Symbol.Of(TokenType.UntilOp), Symbol.Of(NonTerminal.G), Symbol.Of(TokenType.Semicolon) }),
                new(11, NonTerminal.G,  new[] { Symbol.Of(TokenType.UnNot), Symbol.Of(NonTerminal.G) }),
                new(12, NonTerminal.G,  new[] { Symbol.Of(NonTerminal.G1) }),
                new(13, NonTerminal.G1, new[] { Symbol.Of(NonTerminal.G1), Symbol.Of(TokenType.BinAnd), Symbol.Of(NonTerminal.G2) }),
                new(14, NonTerminal.G1, new[] { Symbol.Of(NonTerminal.G2) }),
                new(15, NonTerminal.G2, new[] { Symbol.Of(NonTerminal.G2), Symbol.Of(TokenType.BinOr), Symbol.Of(NonTerminal.G3) }),
                new(16, NonTerminal.G2, new[] { Symbol.Of(NonTerminal.G3) }),
                new(17, NonTerminal.G3, new[] { Symbol.Of(NonTerminal.G3), Symbol.Of(TokenType.BinEqu), Symbol.Of(NonTerminal.P) }),
                new(18, NonTerminal.G3, new[] { Symbol.Of(NonTerminal.P) }),
                new(19, NonTerminal.P,  new[] { Symbol.Of(TokenType.LParen), Symbol.Of(NonTerminal.G), Symbol.Of(TokenType.RParen) }),
                new(20, NonTerminal.P,  new[] { Symbol.Of(NonTerminal.E) }),
                new(21, NonTerminal.P,  new[] { Symbol.Of(NonTerminal.M) }),
                new(22, NonTerminal.E,  new[] { Symbol.Of(NonTerminal.N) }),
                new(23, NonTerminal.E,  new[] { Symbol.Of(NonTerminal.E), Symbol.Of(NonTerminal.N) }),
                new(24, NonTerminal.N,  new[] { Symbol.Of(TokenType.Identifier) }),
                new(25, NonTerminal.M,  new[] { Symbol.Of(TokenType.ZeroConst) }),
                new(26, NonTerminal.M,  new[] { Symbol.Of(TokenType.OneConst) })
            };

            var action = new Dictionary<(int, TokenType), ParserAction>
            {
                // 0
                [(0, TokenType.KeywordVar)] = new ParserAction(ActionKind.Shift, 1),
                // 1
                [(1, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 2
                [(2, TokenType.KeywordBegin)] = new ParserAction(ActionKind.Shift, 7),
                // 3
                [(3, TokenType.Colon)] = new ParserAction(ActionKind.Reduce, 24),
                [(3, TokenType.Comma)] = new ParserAction(ActionKind.Reduce, 24),
                [(3, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 24),
                [(3, TokenType.Assign)] = new ParserAction(ActionKind.Reduce, 24),
                [(3, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 24),
                [(3, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 24),
                [(3, TokenType.BinOr)] = new ParserAction(ActionKind.Reduce, 24),
                [(3, TokenType.BinEqu)] = new ParserAction(ActionKind.Reduce, 24),
                [(3, TokenType.Identifier)] = new ParserAction(ActionKind.Reduce, 24),
                // 4
                [(4, TokenType.Colon)] = new ParserAction(ActionKind.Reduce, 22),
                [(4, TokenType.Comma)] = new ParserAction(ActionKind.Reduce, 22),
                [(4, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 22),
                [(4, TokenType.Assign)] = new ParserAction(ActionKind.Reduce, 22),
                [(4, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 22),
                [(4, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 22),
                [(4, TokenType.BinOr)] = new ParserAction(ActionKind.Reduce, 22),
                [(4, TokenType.BinEqu)] = new ParserAction(ActionKind.Reduce, 22),
                [(4, TokenType.Identifier)] = new ParserAction(ActionKind.Reduce, 22),
                // 5
                [(5, TokenType.Colon)] = new ParserAction(ActionKind.Reduce, 3),
                [(5, TokenType.Comma)] = new ParserAction(ActionKind.Reduce, 3),
                [(5, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 3),
                [(5, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 6
                [(6, TokenType.Colon)] = new ParserAction(ActionKind.Shift, 10),
                [(6, TokenType.Comma)] = new ParserAction(ActionKind.Shift, 11),
                // 7
                [(7, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                [(7, TokenType.ReadOp)] = new ParserAction(ActionKind.Shift, 12),
                [(7, TokenType.WriteOp)] = new ParserAction(ActionKind.Shift, 13),
                [(7, TokenType.RepeatOp)] = new ParserAction(ActionKind.Shift, 14),
                // 8
                [(8, TokenType.Eof)] = new ParserAction(ActionKind.Accept, 0),
                // 9
                [(9, TokenType.Colon)] = new ParserAction(ActionKind.Reduce, 23),
                [(9, TokenType.Comma)] = new ParserAction(ActionKind.Reduce, 23),
                [(9, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 23),
                [(9, TokenType.Assign)] = new ParserAction(ActionKind.Reduce, 23),
                [(9, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 23),
                [(9, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 23),
                [(9, TokenType.BinOr)] = new ParserAction(ActionKind.Reduce, 23),
                [(9, TokenType.BinEqu)] = new ParserAction(ActionKind.Reduce, 23),
                [(9, TokenType.Identifier)] = new ParserAction(ActionKind.Reduce, 23),
                // 10
                [(10, TokenType.KeywordLogical)] = new ParserAction(ActionKind.Shift, 18),
                // 11
                [(11, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 12
                [(12, TokenType.LParen)] = new ParserAction(ActionKind.Shift, 20),
                // 13
                [(13, TokenType.LParen)] = new ParserAction(ActionKind.Shift, 21),
                // 14
                [(14, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                [(14, TokenType.ReadOp)] = new ParserAction(ActionKind.Shift, 12),
                [(14, TokenType.WriteOp)] = new ParserAction(ActionKind.Shift, 13),
                [(14, TokenType.RepeatOp)] = new ParserAction(ActionKind.Shift, 14),
                // 15
                [(15, TokenType.KeywordEnd)] = new ParserAction(ActionKind.Shift, 23),
                [(15, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                [(15, TokenType.ReadOp)] = new ParserAction(ActionKind.Shift, 12),
                [(15, TokenType.WriteOp)] = new ParserAction(ActionKind.Shift, 13),
                [(15, TokenType.RepeatOp)] = new ParserAction(ActionKind.Shift, 14),
                // 16
                [(16, TokenType.KeywordEnd)] = new ParserAction(ActionKind.Reduce, 5),
                [(16, TokenType.UntilOp)] = new ParserAction(ActionKind.Reduce, 5),
                [(16, TokenType.Identifier)] = new ParserAction(ActionKind.Reduce, 5),
                [(16, TokenType.ReadOp)] = new ParserAction(ActionKind.Reduce, 5),
                [(16, TokenType.WriteOp)] = new ParserAction(ActionKind.Reduce, 5),
                [(16, TokenType.RepeatOp)] = new ParserAction(ActionKind.Reduce, 5),
                // 17
                [(17, TokenType.Assign)] = new ParserAction(ActionKind.Shift, 25),
                [(17, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 18
                [(18, TokenType.Semicolon)] = new ParserAction(ActionKind.Shift, 26),
                // 19
                [(19, TokenType.Colon)] = new ParserAction(ActionKind.Reduce, 4),
                [(19, TokenType.Comma)] = new ParserAction(ActionKind.Reduce, 4),
                [(19, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 4),
                [(19, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 20
                [(20, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 21
                [(21, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 22
                [(22, TokenType.UntilOp)] = new ParserAction(ActionKind.Shift, 29),
                [(22, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                [(22, TokenType.ReadOp)] = new ParserAction(ActionKind.Shift, 12),
                [(22, TokenType.WriteOp)] = new ParserAction(ActionKind.Shift, 13),
                [(22, TokenType.RepeatOp)] = new ParserAction(ActionKind.Shift, 14),
                // 23
                [(23, TokenType.Eof)] = new ParserAction(ActionKind.Reduce, 2),
                // 24
                [(24, TokenType.KeywordEnd)] = new ParserAction(ActionKind.Reduce, 6),
                [(24, TokenType.UntilOp)] = new ParserAction(ActionKind.Reduce, 6),
                [(24, TokenType.Identifier)] = new ParserAction(ActionKind.Reduce, 6),
                [(24, TokenType.ReadOp)] = new ParserAction(ActionKind.Reduce, 6),
                [(24, TokenType.WriteOp)] = new ParserAction(ActionKind.Reduce, 6),
                [(24, TokenType.RepeatOp)] = new ParserAction(ActionKind.Reduce, 6),
                // 25
                [(25, TokenType.UnNot)] = new ParserAction(ActionKind.Shift, 30),
                [(25, TokenType.LParen)] = new ParserAction(ActionKind.Shift, 31),
                [(25, TokenType.ZeroConst)] = new ParserAction(ActionKind.Shift, 32),
                [(25, TokenType.OneConst)] = new ParserAction(ActionKind.Shift, 33),
                [(25, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 26
                [(26, TokenType.KeywordBegin)] = new ParserAction(ActionKind.Reduce, 1),
                // 27
                [(27, TokenType.RParen)] = new ParserAction(ActionKind.Shift, 40),
                [(27, TokenType.Comma)] = new ParserAction(ActionKind.Shift, 11),
                // 28
                [(28, TokenType.RParen)] = new ParserAction(ActionKind.Shift, 41),
                [(28, TokenType.Comma)] = new ParserAction(ActionKind.Shift, 11),
                // 29
                [(29, TokenType.UnNot)] = new ParserAction(ActionKind.Shift, 30),
                [(29, TokenType.LParen)] = new ParserAction(ActionKind.Shift, 31),
                [(29, TokenType.ZeroConst)] = new ParserAction(ActionKind.Shift, 32),
                [(29, TokenType.OneConst)] = new ParserAction(ActionKind.Shift, 33),
                [(29, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 30
                [(30, TokenType.UnNot)] = new ParserAction(ActionKind.Shift, 30),
                [(30, TokenType.LParen)] = new ParserAction(ActionKind.Shift, 31),
                [(30, TokenType.ZeroConst)] = new ParserAction(ActionKind.Shift, 32),
                [(30, TokenType.OneConst)] = new ParserAction(ActionKind.Shift, 33),
                [(30, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 31
                [(31, TokenType.UnNot)] = new ParserAction(ActionKind.Shift, 30),
                [(31, TokenType.LParen)] = new ParserAction(ActionKind.Shift, 31),
                [(31, TokenType.ZeroConst)] = new ParserAction(ActionKind.Shift, 32),
                [(31, TokenType.OneConst)] = new ParserAction(ActionKind.Shift, 33),
                [(31, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 32
                [(32, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 25),
                [(32, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 25),
                [(32, TokenType.BinOr)] = new ParserAction(ActionKind.Reduce, 25),
                [(32, TokenType.BinEqu)] = new ParserAction(ActionKind.Reduce, 25),
                [(32, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 25),
                // 33
                [(33, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 26),
                [(33, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 26),
                [(33, TokenType.BinOr)] = new ParserAction(ActionKind.Reduce, 26),
                [(33, TokenType.BinEqu)] = new ParserAction(ActionKind.Reduce, 26),
                [(33, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 26),
                // 34
                [(34, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 12),
                [(34, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 12),
                [(34, TokenType.BinAnd)] = new ParserAction(ActionKind.Shift, 45),
                // 35 (Добавлен Semicolon)
                [(35, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 14),
                [(35, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 14),
                [(35, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 14),
                [(35, TokenType.BinOr)] = new ParserAction(ActionKind.Shift, 46),
                // 36 (Добавлен Semicolon)
                [(36, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 16),
                [(36, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 16),
                [(36, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 16),
                [(36, TokenType.BinOr)] = new ParserAction(ActionKind.Reduce, 16),
                [(36, TokenType.BinEqu)] = new ParserAction(ActionKind.Shift, 47),
                // 37 (Добавлен Semicolon)
                [(37, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 18),
                [(37, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 18),
                [(37, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 18),
                [(37, TokenType.BinOr)] = new ParserAction(ActionKind.Reduce, 18),
                [(37, TokenType.BinEqu)] = new ParserAction(ActionKind.Reduce, 18),
                // 38 (Добавлен Semicolon)
                [(38, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 20),
                [(38, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 20),
                [(38, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 20),
                [(38, TokenType.BinOr)] = new ParserAction(ActionKind.Reduce, 20),
                [(38, TokenType.BinEqu)] = new ParserAction(ActionKind.Reduce, 20),
                [(38, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 39 (Добавлен Semicolon)
                [(39, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 21),
                [(39, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 21),
                [(39, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 21),
                [(39, TokenType.BinOr)] = new ParserAction(ActionKind.Reduce, 21),
                [(39, TokenType.BinEqu)] = new ParserAction(ActionKind.Reduce, 21),
                // 40
                [(40, TokenType.Semicolon)] = new ParserAction(ActionKind.Shift, 48),
                // 41
                [(41, TokenType.Semicolon)] = new ParserAction(ActionKind.Shift, 49),
                // 42
                [(42, TokenType.Semicolon)] = new ParserAction(ActionKind.Shift, 50),
                // 43
                [(43, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 11),
                [(43, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 11),
                [(43, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 11),
                [(43, TokenType.BinOr)] = new ParserAction(ActionKind.Reduce, 11),
                [(43, TokenType.BinEqu)] = new ParserAction(ActionKind.Reduce, 11),
                // 44
                [(44, TokenType.RParen)] = new ParserAction(ActionKind.Shift, 51),
                // 45
                [(45, TokenType.UnNot)] = new ParserAction(ActionKind.Shift, 30),
                [(45, TokenType.LParen)] = new ParserAction(ActionKind.Shift, 31),
                [(45, TokenType.ZeroConst)] = new ParserAction(ActionKind.Shift, 32),
                [(45, TokenType.OneConst)] = new ParserAction(ActionKind.Shift, 33),
                [(45, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 46
                [(46, TokenType.UnNot)] = new ParserAction(ActionKind.Shift, 30),
                [(46, TokenType.LParen)] = new ParserAction(ActionKind.Shift, 31),
                [(46, TokenType.ZeroConst)] = new ParserAction(ActionKind.Shift, 32),
                [(46, TokenType.OneConst)] = new ParserAction(ActionKind.Shift, 33),
                [(46, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 47
                [(47, TokenType.UnNot)] = new ParserAction(ActionKind.Shift, 30),
                [(47, TokenType.LParen)] = new ParserAction(ActionKind.Shift, 31),
                [(47, TokenType.ZeroConst)] = new ParserAction(ActionKind.Shift, 32),
                [(47, TokenType.OneConst)] = new ParserAction(ActionKind.Shift, 33),
                [(47, TokenType.Identifier)] = new ParserAction(ActionKind.Shift, 3),
                // 48
                [(48, TokenType.KeywordEnd)] = new ParserAction(ActionKind.Reduce, 8),
                [(48, TokenType.UntilOp)] = new ParserAction(ActionKind.Reduce, 8),
                [(48, TokenType.Identifier)] = new ParserAction(ActionKind.Reduce, 8),
                [(48, TokenType.ReadOp)] = new ParserAction(ActionKind.Reduce, 8),
                [(48, TokenType.WriteOp)] = new ParserAction(ActionKind.Reduce, 8),
                [(48, TokenType.RepeatOp)] = new ParserAction(ActionKind.Reduce, 8),
                // 49
                [(49, TokenType.KeywordEnd)] = new ParserAction(ActionKind.Reduce, 9),
                [(49, TokenType.UntilOp)] = new ParserAction(ActionKind.Reduce, 9),
                [(49, TokenType.Identifier)] = new ParserAction(ActionKind.Reduce, 9),
                [(49, TokenType.ReadOp)] = new ParserAction(ActionKind.Reduce, 9),
                [(49, TokenType.WriteOp)] = new ParserAction(ActionKind.Reduce, 9),
                [(49, TokenType.RepeatOp)] = new ParserAction(ActionKind.Reduce, 9),
                // 50
                [(50, TokenType.KeywordEnd)] = new ParserAction(ActionKind.Reduce, 10),
                [(50, TokenType.UntilOp)] = new ParserAction(ActionKind.Reduce, 10),
                [(50, TokenType.Identifier)] = new ParserAction(ActionKind.Reduce, 10),
                [(50, TokenType.ReadOp)] = new ParserAction(ActionKind.Reduce, 10),
                [(50, TokenType.WriteOp)] = new ParserAction(ActionKind.Reduce, 10),
                [(50, TokenType.RepeatOp)] = new ParserAction(ActionKind.Reduce, 10),
                // 51
                [(51, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 19),
                [(51, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 19),
                [(51, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 19),
                [(51, TokenType.BinOr)] = new ParserAction(ActionKind.Reduce, 19),
                [(51, TokenType.BinEqu)] = new ParserAction(ActionKind.Reduce, 19),
                // 52 (Добавлен Semicolon)
                [(52, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 13),
                [(52, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 13),
                [(52, TokenType.BinOr)] = new ParserAction(ActionKind.Shift, 46),
                // 53 (Добавлен Semicolon)
                [(53, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 15),
                [(53, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 15),
                [(53, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 15),
                [(53, TokenType.BinEqu)] = new ParserAction(ActionKind.Shift, 47),
                // 54 (Добавлен Semicolon)
                [(54, TokenType.RParen)] = new ParserAction(ActionKind.Reduce, 17),
                [(54, TokenType.Semicolon)] = new ParserAction(ActionKind.Reduce, 17),
                [(54, TokenType.BinAnd)] = new ParserAction(ActionKind.Reduce, 17),
                [(54, TokenType.BinOr)] = new ParserAction(ActionKind.Reduce, 17),
                // 55
                [(55, TokenType.Semicolon)] = new ParserAction(ActionKind.Shift, 56),
                // 56
                [(56, TokenType.KeywordEnd)] = new ParserAction(ActionKind.Reduce, 7),
                [(56, TokenType.UntilOp)] = new ParserAction(ActionKind.Reduce, 7),
                [(56, TokenType.Identifier)] = new ParserAction(ActionKind.Reduce, 7),
                [(56, TokenType.ReadOp)] = new ParserAction(ActionKind.Reduce, 7),
                [(56, TokenType.WriteOp)] = new ParserAction(ActionKind.Reduce, 7),
                [(56, TokenType.RepeatOp)] = new ParserAction(ActionKind.Reduce, 7),
            };

            var gotoTable = new Dictionary<(int, NonTerminal), int>
            {
                [(0, NonTerminal.A)] = 2,
                [(1, NonTerminal.D)] = 6,
                [(1, NonTerminal.E)] = 5,
                [(1, NonTerminal.N)] = 4,
                [(2, NonTerminal.B)] = 8,
                [(5, NonTerminal.N)] = 9,
                [(7, NonTerminal.C)] = 15,
                [(7, NonTerminal.F)] = 16,
                [(7, NonTerminal.E)] = 17,
                [(7, NonTerminal.N)] = 4,
                [(11, NonTerminal.E)] = 19,
                [(11, NonTerminal.N)] = 4,
                [(14, NonTerminal.C)] = 22,
                [(14, NonTerminal.F)] = 16,
                [(14, NonTerminal.E)] = 17,
                [(14, NonTerminal.N)] = 4,
                [(15, NonTerminal.F)] = 24,
                [(15, NonTerminal.E)] = 17,
                [(15, NonTerminal.N)] = 4,
                [(17, NonTerminal.N)] = 9,
                [(19, NonTerminal.N)] = 9,
                [(20, NonTerminal.D)] = 27,
                [(20, NonTerminal.E)] = 5,
                [(20, NonTerminal.N)] = 4,
                [(21, NonTerminal.D)] = 28,
                [(21, NonTerminal.E)] = 5,
                [(21, NonTerminal.N)] = 4,
                [(22, NonTerminal.F)] = 24,
                [(22, NonTerminal.E)] = 17,
                [(22, NonTerminal.N)] = 4,
                [(25, NonTerminal.G)] = 55,
                [(25, NonTerminal.G1)] = 34,
                [(25, NonTerminal.G2)] = 35,
                [(25, NonTerminal.G3)] = 36,
                [(25, NonTerminal.P)] = 37,
                [(25, NonTerminal.E)] = 38,
                [(25, NonTerminal.M)] = 39,
                [(25, NonTerminal.N)] = 4,
                [(29, NonTerminal.G)] = 42,
                [(29, NonTerminal.G1)] = 34,
                [(29, NonTerminal.G2)] = 35,
                [(29, NonTerminal.G3)] = 36,
                [(29, NonTerminal.P)] = 37,
                [(29, NonTerminal.E)] = 38,
                [(29, NonTerminal.M)] = 39,
                [(29, NonTerminal.N)] = 4,
                [(30, NonTerminal.G)] = 43,
                [(30, NonTerminal.G1)] = 34,
                [(30, NonTerminal.G2)] = 35,
                [(30, NonTerminal.G3)] = 36,
                [(30, NonTerminal.P)] = 37,
                [(30, NonTerminal.E)] = 38,
                [(30, NonTerminal.M)] = 39,
                [(30, NonTerminal.N)] = 4,
                [(31, NonTerminal.G)] = 44,
                [(31, NonTerminal.G1)] = 34,
                [(31, NonTerminal.G2)] = 35,
                [(31, NonTerminal.G3)] = 36,
                [(31, NonTerminal.P)] = 37,
                [(31, NonTerminal.E)] = 38,
                [(31, NonTerminal.M)] = 39,
                [(31, NonTerminal.N)] = 4,
                [(38, NonTerminal.N)] = 9,
                [(45, NonTerminal.G2)] = 52,
                [(45, NonTerminal.G3)] = 36,
                [(45, NonTerminal.P)] = 37,
                [(45, NonTerminal.E)] = 38,
                [(45, NonTerminal.M)] = 39,
                [(45, NonTerminal.N)] = 4,
                [(46, NonTerminal.G3)] = 53,
                [(46, NonTerminal.P)] = 37,
                [(46, NonTerminal.E)] = 38,
                [(46, NonTerminal.M)] = 39,
                [(46, NonTerminal.N)] = 4,
                [(47, NonTerminal.P)] = 54,
                [(47, NonTerminal.E)] = 38,
                [(47, NonTerminal.M)] = 39,
                [(47, NonTerminal.N)] = 4,
            };

            return new ParserTable { Rules = rules, Action = action, Goto = gotoTable };
        }
    }
}