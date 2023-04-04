class DummyApp
{
    public static void Main(string[] args)
    {
        Console.Write($"DummyApp's Arguments: ");

        if (args.Length > 0)
        {
            int counter = 0;

            foreach (string item in args)
            {
                ++counter;
                Console.Write($"#{counter}: {item} ");
            }
            
        } else 
        {
            Console.Write("No Arguments.");
        }

        Console.WriteLine();
    }
}