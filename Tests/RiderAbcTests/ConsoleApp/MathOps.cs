namespace ConsoleApp;
public static class MathOps
{
    public static void Tests()
    {
        int a = 25;
        int b = 7;
        decimal result = decimal.Divide(a, b);
        Console.WriteLine(result);
        Console.WriteLine(Math.Round(result, 1));
    }
}