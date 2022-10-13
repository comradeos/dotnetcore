namespace HelloDotNetConsole;

public class Lesson04
{
    public static void Run()
    {
        double doubleUserInput;
        Console.Write("Input doubleUserInput: ");
        doubleUserInput = Convert.ToDouble(Console.ReadLine());
        
        float floatUserInput;
        Console.Write("Input floatUserInput: ");
        floatUserInput = float.Parse(Console.ReadLine());
        
        Console.WriteLine("doubleUserInput: " + doubleUserInput + ", floatUserInput: " + floatUserInput);
        
    }
}