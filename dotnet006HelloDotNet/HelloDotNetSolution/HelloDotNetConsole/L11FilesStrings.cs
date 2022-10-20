namespace HelloDotNetConsole;
using Tools = L00Tools;
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
        
        string connectionString =
            "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=true";

        // Provide the query string with a parameter placeholder.
        string queryString =
            "SELECT ProductID, UnitPrice, ProductName from dbo.products "
            + "WHERE UnitPrice > @pricePoint "
            + "ORDER BY UnitPrice DESC;";
        
        
    }
    
}