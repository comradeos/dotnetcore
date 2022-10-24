namespace HelloDotNetConsole;
using Tools = L00Tools;

using System;
using System.IO;

public static class L11FilesStrings
{
    public static void Run()
    {
        var word = "abc";
        word += "def";
        Console.WriteLine(word);  // abcdef
        Console.WriteLine(word.Length);  // 6
        
        Tools.Line();
        
        Console.WriteLine(string.Concat("Hello", "!!!")); // объединение строк

        
        Console.WriteLine(string.CompareOrdinal("1", "1"));  // 0
        Console.WriteLine(string.CompareOrdinal("11", "1"));  // 49 
        Console.WriteLine(string.CompareOrdinal("1", "11"));  // -49

        const string people = "Alex, Bob, John";
        var names = people.Split(','); // разбить строку на массив елементов
        foreach (var item in names)
        {
            Console.WriteLine(item.Trim());  // убрать пробелы по бокам
        }
        
        var array = new string[]
        {
            "Hello",
            "world",
            "!",
        };
        var newStr = string.Join(" ", array); // соединить массив в строку 
        Console.WriteLine(newStr);  
        Console.WriteLine("abcdef".Substring(2,1)); // вывести один символ начиная с 2го

        
        Console.WriteLine("Введите текст: ");
        var text = Console.ReadLine();  // считать текст из консоли
        using var stream = new FileStream("info.txt", FileMode.OpenOrCreate);
        if (text != null) // проверка тект на не пустоту
        {
            var bytesArray = System.Text.Encoding.Default.GetBytes(text); // преобразовать текст в массив байтов
            stream.Write(bytesArray, 0, bytesArray.Length);
            foreach (var i in bytesArray)
            {
                Console.WriteLine(bytesArray);
            }
        }
        
    }
    
}