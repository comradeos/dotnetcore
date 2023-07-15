namespace Console;

public class ClassRecTest
{
    public int Number { get; set; }
    public ClassRecTest Obj { get; set; } 
}

public static class ClassRec
{
    public static void Tests()
    {
        ClassRecTest crt = new()
        {
            Number = 25
        };

        ClassRecTest classRecTest = new()
        {
            Number = 777,
            Obj = crt
        };

        System.Console.WriteLine(classRecTest.Number);
        System.Console.WriteLine(classRecTest.Obj.Number);

    }
}