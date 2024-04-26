namespace ConsoleApp.Modules;

public class IntDecimal
{
    public static void Test()
    {
        const decimal decNum = (decimal)1.25;
        const int intNum = (int)decNum;
        Console.WriteLine(intNum);
    }
}