using System;
using System.Text;

namespace HelloDotNetConsole
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; // кирилица в консоли
            int num1 = -231; // и положительные и отрицательные
            uint num2 = 231; // только положительные
            byte num3 = 255; // только в диапазоне 0-255
            Console.WriteLine("переменная num1: " + num1 + ".");
            Console.WriteLine("переменная num2: " + num2 + ".");
            Console.WriteLine("переменная num1: " + num3 + ".");
            // Console.ReadKey(); // считать один символ
        }  
    }
    
}

