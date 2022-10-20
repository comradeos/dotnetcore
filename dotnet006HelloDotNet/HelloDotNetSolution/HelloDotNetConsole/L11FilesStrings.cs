namespace HelloDotNetConsole;
using Tools = L00Tools;

using System;
using System.Data;
using System.Data.SqlClient;

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
        

        
        
    }
    
}