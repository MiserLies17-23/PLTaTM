using PLTaTM;

internal class Program
{
    private static void Main(string[] args)
    {
        LexicalAnalyzer analyzer = new LexicalAnalyzer();

        Console.WriteLine("Напишите фрагмент кода: ");
        var line = Console.ReadLine();

        var tokens = analyzer.Analyze(line);
        foreach (var token in tokens)
        {
            Console.WriteLine($"{token.Value} - {token.Type.ToString()}");
        }
    }
}