using MyLibrary;

public class Program
{
    public static void Main(String[] args)
    {
        MyModel myModel = new()
        {
            Id = 5532,
            Name = "MyModel1Name"
        };

        Console.WriteLine($"{myModel.Id} :: {myModel.Name}");
    }
}