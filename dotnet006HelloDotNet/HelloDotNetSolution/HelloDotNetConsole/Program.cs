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
            Console.WriteLine("переменная" + number + ".");
            // Console.ReadKey(); // считать один символ
        }  
    }
    
}

