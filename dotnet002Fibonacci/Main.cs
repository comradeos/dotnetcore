﻿namespace poop
{
    class Program
    {
        public static int fib(int i)
        {
            if (i <= 2) return 1;
            return fib(i - 2) + fib(i - 1);
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine(fib(20));
        }
    }

}