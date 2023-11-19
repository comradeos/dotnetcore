namespace ConsoleApp.Patterns;

public static class AbstractFactory
{
    public static void Test()
    {
        VictorianIFurnitureFactory factory = new();
        IChair chair = factory.CreateChair();
        chair.SitOn();
    }
}

internal interface IChair
{
    int LegsNumber { get; set; }
    string Color { get; set; }
    void SitOn();
}

internal class Chair : IChair
{
    public int LegsNumber { get; set; }
    public string Color { get; set; }
    public string Epoch { get; set; } = "unknown";

    public Chair(int legs, string color)
    {
        LegsNumber = legs;
        Color = color;
    }

    public void SitOn()
    {
        Console.WriteLine($"You are sitting on {Color} chair with {LegsNumber} legs...");
    }
}

internal interface IFurnitureFactory
{
    IChair CreateChair();
}

internal class VictorianIFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        Chair chair = new(3, "red")
        {
            Epoch = "Victorian"
        };

        Console.WriteLine($"{chair.Epoch}'s epoch {chair.Color} colored chair with {chair.LegsNumber} legs created!");
        
        return chair;
    }
}

