namespace Console;

public class ClassRecTest
{
    public int Number { get; set; }
    public ClassRecTest classRecTest { get; set; } 
}

public static class ClassRec
{
    public static void Tests()
    {
        ClassRecTest crt = new()
        {
            number = 25
        };

        ClassRecTest classRecTest = new()
        {
            number = 777,
            classRecTest = crt
        };

        System.Console.WriteLine(classRecTest.number);
        System.Console.WriteLine(classRecTest.classRecTest.number);

    }
}