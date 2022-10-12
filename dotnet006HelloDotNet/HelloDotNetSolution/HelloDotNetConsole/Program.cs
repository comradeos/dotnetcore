using System;
using System.Text;

namespace HelloDotNetConsole
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; // кирилица в консоли

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

            float fnum = 249123.2142f;
            double dnum = 214412552324532423.21231452312312342d;
            Console.WriteLine("переменная fnum: " + fnum);
            Console.WriteLine("переменная dnum: " + dnum);



            // Console.ReadKey(); // считать один символ
        }  
    }
    
}

