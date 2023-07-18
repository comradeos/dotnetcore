namespace Console;

public class MathOps
{
    public static void Tests()
    {
        int a = 25;
        int b = 7;
        decimal result = decimal.Divide(a, b);
        System.Console.WriteLine(result);
        System.Console.WriteLine(Math.Round(result, 1));
    }
}