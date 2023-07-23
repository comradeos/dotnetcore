namespace ConsoleApp;
public static class MathOps
{
    public static void Tests()
    {
        var a = 25;
        var b = 7;
        var result = decimal.Divide(a, b);
        Console.WriteLine(result);
        Console.WriteLine(Math.Round(result, 1));
    }
}