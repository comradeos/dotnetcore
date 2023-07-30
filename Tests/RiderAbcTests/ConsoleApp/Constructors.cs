namespace ConsoleApp;

public class A
{
    public int Id { get; set; } = 1;
    public string Name { get; set; } = "Default Name";

    public A()
    {
        Console.WriteLine("A obj created!");
    }
}

public class Constructors
{
    public static void Tests()
    {
        A a = new();
        Console.WriteLine(a.Id);
        Console.WriteLine(a.Name);
    }
}