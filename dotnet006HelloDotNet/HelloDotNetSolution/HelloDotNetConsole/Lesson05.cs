﻿namespace HelloDotNetConsole;

public static class Lesson05
{
    public static void Run()
    {
        string word = "abc";
        
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

        const bool isHappy = true;
        const string result = isHappy ? "You are happy!" : "You are not happy...";
        Console.WriteLine(result);
        
        const int num = 3;
        
        if (num > 5)
        {
            Console.WriteLine(" > 5 ...");
        } else if (num > 1)
        {
            Console.WriteLine(" > 1 ...");
        }

    }
}