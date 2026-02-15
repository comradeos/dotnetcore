namespace Demos;

interface IShape
{
    string GetName();
    void Draw();
}

abstract class Shape : IShape
{
    private string Name { get; set; }

    protected Shape(string name)
    {
        Name = name;
    }

    public string GetName()
    {
        return Name;
    }

    public void Draw()
    {
        Console.WriteLine($"Drawing the {Name}...");
    }
}

class Circle : Shape
{
    public Circle(string name) : base(name)
    {
        Console.WriteLine($"Creating {name}...");    
    }
}

class Box : Shape
{
    public Box(string name) : base(name)
    {
        Console.WriteLine($"Creating {name}...");    
    }
}

public static class Abstraction
{
    public static void Demo()
    {
        Circle circle = new("Circle");
        circle.Draw();
        ProcessAbstraction(circle);
        ProcessInterface(circle);
        
        Box box = new("Box");
        box.Draw();
        ProcessAbstraction(box);
        ProcessInterface(box);
    }

    private static void ProcessAbstraction(Shape shape)
    {
        Console.WriteLine($"Processing the {shape.GetName()}...");
    }
    
    private static void ProcessInterface(IShape shape) // CA1859: Change type of parameter 'shape' from 'Demos.IShape' to 'Demos.Circle' for improved performance
    {
        Console.WriteLine($"Processing the {shape.GetName()}...");
    }    
}

