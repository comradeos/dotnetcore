﻿namespace HelloDotNetConsole;

public static class Lesson04
{
    public static void Run()
    {
        // Console.Write("Input doubleUserInput: ");
        // var doubleUserInput = Convert.ToDouble(Console.ReadLine());
        
        // Console.Write("Input floatUserInput: ");
        // var floatUserInput = float.Parse(Console.ReadLine() ?? string.Empty);

        // Console.WriteLine("doubleUserInput: " + doubleUserInput + ", floatUserInput: " + floatUserInput);

        const float a = 21.23f;
        const float b = 61.01f;
        
        Console.WriteLine("a = " + a + "b = " + b);
        Console.WriteLine("a + b = " + (a + b));
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b));
        Console.WriteLine("a / b = " + (a / b));
        Console.WriteLine("a % b = " + (a % b));

    }
}