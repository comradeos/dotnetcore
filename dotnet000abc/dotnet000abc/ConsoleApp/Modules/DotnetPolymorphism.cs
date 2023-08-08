namespace ConsoleApp.Modules;


public class Animal
{
    public string Name { get; set; } = default!;
    
    public void Sound()
    {
        Console.WriteLine("Animal sound...");
    }
}

public class Cat : Animal
{
    public void Sound()
    {
        Console.WriteLine($"{Name} makes cat sound...");
    }
}

public class Dog : Animal
{
    public void Sound()
    {
        Console.WriteLine($"{Name} makes dog sound...");
    }
}


public static class DotnetPolymorphism
{
    public static void Test()
    {
        Cat cat = new();
        cat.Name = "Kotski";
        cat.Sound();

        Dog dog = new();
        dog.Name = "Sobaken";
        dog.Sound();
    }
}