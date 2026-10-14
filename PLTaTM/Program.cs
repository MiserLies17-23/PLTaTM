using PLTaTM.Grammer;
using PLTaTM.LexicalAnalyzer;
using PLTaTM.SyntaxAnalyzer;

internal class Program
{
    private static void Main(string[] args)
    {
        LexicalAnalyzer lAnalyzer = new LexicalAnalyzer();
        
        //ParserTable pt = new ParserTable(Grammar.Rules, );
        //SyntaxAnalyzer sAnalyzer = new SyntaxAnalyzer(new ParserTable(Grammar.Rules));
        
        Console.WriteLine("Напишите фрагмент кода: ");
        var line = Console.ReadLine();

        var tokens = lAnalyzer.Analyze(line);
        foreach (var token in tokens)
        {
            Console.WriteLine($"{token.Value} - {token.Type.ToString()}");
        }
    }
}