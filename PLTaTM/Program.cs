using PLTaTM.LexicalAnalyzer;
using PLTaTM.SyntaxAnalyzer;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            LexicalAnalyzer lAnalyzer = new LexicalAnalyzer();
            SyntaxAnalyzer sAnalyzer = new SyntaxAnalyzer(ManualParserTable.Create());

            string path = "C:\\Users\\THUNDEROBOT\\source\\repos\\PLTaTM\\PLTaTM\\code.txt";

            string fileText = File.ReadAllText(path);
            bool flag = sAnalyzer.Parse(lAnalyzer.Analyze(fileText));
            string msg = flag ? "Синтаксический анализ успешно завершён!"
                : "Синтаксический анализ завершился с ошибкой";
            Console.WriteLine(msg);
        }
        catch (Exception ex) 
        { 
            Console.WriteLine(ex.Message);
        }
    }
}