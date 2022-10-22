namespace HelloDotNetConsole;

public static class L10FunctionsClassMethods
{
    /**
     * Чего-то там печатает
     */
    public static void Print(string word)
    {
        Console.WriteLine(word);
    }


    public static void Run()
    {
        Print("Hello");
        Print("World");
        Print("!");
        const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
        // Создание подключения
    }
}