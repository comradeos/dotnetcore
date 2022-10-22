namespace HelloDotNetConsole;
using Tools = L00Tools;

using System;

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



    }
    
}