namespace ConsoleApp2;

public class A
{
    public int Id { get; set; } = 1;
    public string Name { get; set; } = "Default Name";

    public A()
    {
        this.Id = 25;
        Console.WriteLine("A obj created!");
    }
};

public static class Program
{
    public static void Main()
    {
        A a = new();
        Console.WriteLine(a.Id);
        Console.WriteLine(a.Name);
    }
}
