namespace ConsoleApp.Modules;

public static class ListToStringCommaSeparated
{
    public static void Test()
    {
        List<int> numbers = new() { 1, 2, 3 };
        string strNumbers = $"({string.Join(",", numbers)})";
        Console.WriteLine(strNumbers);
    }
}