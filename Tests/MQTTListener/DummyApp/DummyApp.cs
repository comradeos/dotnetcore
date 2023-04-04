class DummyApp
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"This a dummy app:");

        if (args.Length > 0)
        {
            int counter = 0;

            foreach (string item in args)
            {
                ++counter;
                Console.WriteLine($"Argument #{counter}: {item}");
            }
            
        } else 
        {
            Console.WriteLine("No arguments.");
        }
    }
}