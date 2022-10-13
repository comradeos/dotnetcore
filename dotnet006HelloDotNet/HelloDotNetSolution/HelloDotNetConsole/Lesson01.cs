namespace HelloDotNetConsole;

public class Lesson01
{
    public static void Run()
    {
        // byte number = 10;
        // short number = 10;
        // long number = 10;
        var n = new int();
        n = 231231;
        Console.WriteLine(n);
        
        int num1 = -231; // и положительные и отрицательные
        uint num2 = 231; // только положительные
        byte num3 = 255; // только в диапазоне 0-255

        Console.WriteLine("переменная num1: " + num1 + ".");
        Console.WriteLine("переменная num2: " + num2 + ".");
        Console.WriteLine("переменная num1: " + num3 + ".");
        Console.WriteLine("переменная num1: " + num3 + ".");
    }
}