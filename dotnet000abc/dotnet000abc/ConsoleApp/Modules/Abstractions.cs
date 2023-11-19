namespace ConsoleApp.Modules;

public static class Abstractions
{
    public static void Test()
    {
        Employee_abs iaroslavOs = new("Iaroslav Os", 33);
        iaroslavOs.SayHello();
    }
}

interface ICreature_abs
{
    string name { get; set; }
    int age { get; set; }

    void SayHello();

}

abstract class Human_abs : ICreature_abs
{
    public string name { get; set; } = "unknown";
    public int age { get; set; }

    public void SayHello()
    {
        Console.WriteLine("Hello, I am a human!");
    }
}

class Employee_abs : Human_abs
{
    public Employee_abs(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void SayHello()
    {
        Console.WriteLine($"Hello, my name is {this.name}, I am {this.age} years old!");
    }
    
    public void SayHello(int arg)
    {
        Console.WriteLine($"It's arg.... {arg}");
    }
}