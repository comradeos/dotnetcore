namespace MyLibrary;

internal class MyModel
{
    public int Id
    {
        set
        {
            Console.WriteLine($"Setting ID to {value}...");
        }

        get
        {
            return Id;
        }
    }
    public string Name { get; set; } = "";
}
