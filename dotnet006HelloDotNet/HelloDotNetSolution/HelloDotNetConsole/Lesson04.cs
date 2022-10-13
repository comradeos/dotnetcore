namespace HelloDotNetConsole;

public class Lesson04
{
    public static void Run()
    {
        Console.Write("Input doubleUserInput: ");
        double doubleUserInput = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Input floatUserInput: ");
        float floatUserInput = float.Parse(Console.ReadLine() ?? string.Empty);
        
        Console.WriteLine("doubleUserInput: " + doubleUserInput + ", floatUserInput: " + floatUserInput);
        
    }
}