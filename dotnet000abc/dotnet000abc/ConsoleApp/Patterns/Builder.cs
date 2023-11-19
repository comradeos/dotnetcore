using ConsoleApp.Modules;

namespace ConsoleApp.Patterns;

public static class Builder
{
    public static void Test()
    {
        CarBuilder builder = new();
        BuilderDirector director = new(builder);
        director.MakeCompletedCar();
    }
}

internal class Car
{
    public int Seats { get; set; }
    public int Wheels { get; set; }
    public string Color { get; set; } = "Unknown";
    public string Manufacturer { get; set; } = "Unknown";
}

internal interface IBuilder
{
    void SetSeats(int number);
    void SetWheels(int number);
    void SetColor(string color);
    void SetManufacturer(string manufacturer);
    Car GetCar();
}

internal class CarBuilder : IBuilder
{
    private readonly Car _car = new();

    public void SetSeats(int number)
    {
        _car.Seats = number;
        Console.WriteLine($"Seats added");
    }
    
    public void SetWheels(int number)
    {
        _car.Wheels = number;
        Console.WriteLine($"Wheels added");
    }
        
    public void SetColor(string color)
    {
        _car.Color = color;
        Console.WriteLine($"Color added");
    }
    
    public void SetManufacturer(string manufacturer)
    {
        _car.Manufacturer = manufacturer;
        Console.WriteLine($"Manufacturer set");
    }

    public Car GetCar()
    {
        return _car;
    }
}


internal class BuilderDirector
{
    private readonly IBuilder _builder;

    public BuilderDirector(IBuilder builder)
    {
        _builder = builder;
    }

    public Car MakeCompletedCar()
    {
        _builder.SetManufacturer("BMW");
        _builder.SetColor("red");
        _builder.SetWheels(4);
        _builder.SetSeats(6);
        
        Car car = _builder.GetCar();
        
        Console.WriteLine($"{car.Manufacturer} presenting {car.Color} car with {car.Seats} seats and {car.Wheels} wheels!");
        
        return car;
    }
}

