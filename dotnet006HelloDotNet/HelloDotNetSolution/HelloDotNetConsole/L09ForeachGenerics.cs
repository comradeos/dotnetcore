namespace HelloDotNetConsole;
using System.Collections.Generic;

using Tools = L00Tools;

public static class L09ForeachGenerics
{
    public static void Run()
    {
        short[] nums =
        {
            10, 15, 81, 94, 10,
        }; // массив

        foreach (var num in nums)
        {
            Console.WriteLine(num);
        }


        short[,] nums2 =
        {
            { 1, 2, 3, },
            { 4, 5, 6, },
            { 7, 8, 9, },
        }; // двумерный массив

        
        Tools.Line();

        
        foreach (var num in nums2)
        {
            Console.WriteLine(num);
        }


        var numbers = new List<int>()
        {
            341, 23, 551,
        };  // динамический массив
        
        numbers.Add(777);
        numbers.Add(777);
        numbers.Add(777);

        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }

    }
}