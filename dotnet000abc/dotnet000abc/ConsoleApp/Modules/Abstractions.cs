namespace ConsoleApp.Modules;

public static class Abstractions
{
    public static void Test()
    {
        T10Human p = new T10Human();
        p.SayHello();
    }
}

internal abstract class T10Person
{
    public void SayHello()
    {
        Console.WriteLine("hello!22");
    }
}

internal class T10Human : T10Person
{
    public new void SayHello()
    {
        Console.WriteLine("hellodsds2");
    }
}