﻿namespace HelloDotNetConsole;

using Tools = L00Tools;

public static class L12ExceptionsTryCatch {
    public static void Run() {
        try {
            // var num = Convert.ToInt32(Console.ReadLine());
            var num = Convert.ToInt32("34d1");
            Console.WriteLine("Converted to int32 = " + num);
        }
        catch (FormatException) {
            Console.WriteLine("Был введен не тот формат!");
            //throw; // завершить программу
        }

        Tools.Line();

        var a = 23;
        var b = 0;
        var res = 0;

        try {
            res = a / b;
        }
        catch (DivideByZeroException) {
            Console.WriteLine("Перехвачена ошибка деления на ноль!");
        }

        Console.WriteLine(res);
    }
}