namespace HelloDotNetConsole;

public static class Lesson05
{
    public static void Run()
    {
        var word = "a";
        word = "abc";
        
        if (word.Length > 2)
        {
            Console.WriteLine("cool: ");
            Console.WriteLine("word.Length > 2");
        }
        else
        {
            Console.WriteLine("cool: ");
            Console.WriteLine("word.Length <2");
        }
        
        
        
    }
}