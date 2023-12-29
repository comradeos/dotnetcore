namespace ConsoleApp.Modules;

public static class EnumNames
{
    private enum MyEnum
    {
        FirstName,
        SecondName,
        ThirdName
    }

    private static string GetEnumName(int value)
    {
        return Enum.GetName(typeof(MyEnum), value)!;
    }
    
    public static void Test()
    {
        string enumName = GetEnumName(1);
        Console.WriteLine($"enumName: {enumName}");
        Console.WriteLine($"enumName.ToUpper(): {enumName.ToUpper()}");
    }
}