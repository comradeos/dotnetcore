namespace ConsoleApp;

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
            Number = 1,
            Obj = new ClassRecTest
            {
                Number = 11,
                Obj = new ClassRecTest()
                {
                    Number = 12,
                    Obj = new ClassRecTest()
                    {
                        Number = 13,
                    }
                }
            }
        };

        ClassRecTest classRecTest = new()
        {
            Number = 777,
            Obj = crt
        };

        System.Console.WriteLine(classRecTest.Number);
        System.Console.WriteLine(classRecTest.Obj.Obj.Obj.Obj.Number);
    }
}