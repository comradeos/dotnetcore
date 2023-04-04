class DummyApp
{
    public static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            Console.WriteLine("\n----------------------");
            string content = File.ReadAllText(args[0]);
            Console.WriteLine(content);

            Console.Write($"\nArguments: ");
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