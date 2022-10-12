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
            double dnum = 21441255232453242333333333423423433333333333.21231452312312342d;
            Console.WriteLine("переменная fnum: " + fnum);
            Console.WriteLine("переменная dnum: " + dnum);

            string word = "Переменная";
            Console.WriteLine(word + ": " + dnum);
            
            char symbol = 'A';
            Console.WriteLine("Символ: " + symbol);

            
            bool isHappy = true;
            Console.WriteLine("isHappy: " + isHappy);


            int num_1 = 0, num_2 = 0;
            num_1 = Convert.ToInt32(Console.ReadLine());
            num_2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("num_1: " + num_1 + "\nnum_2: " + num_2);
            
            // Console.ReadKey(); // считать один символ
        }  
    }
    
}

