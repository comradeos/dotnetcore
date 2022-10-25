namespace HelloDotNetConsole;
using Tools = L00Tools;

public static class L12ExceptionsTryCatch
{
    public static void Run()
    {
        
        try
        {
            var num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Converted to int32 = " + num);
        }
        catch (FormatException)
        {
            Console.WriteLine("Был введен не тот формат!");
            throw;
        }

        Console.WriteLine(1);
        Console.WriteLine(2);
        Console.WriteLine(3);
    }
    
    
}