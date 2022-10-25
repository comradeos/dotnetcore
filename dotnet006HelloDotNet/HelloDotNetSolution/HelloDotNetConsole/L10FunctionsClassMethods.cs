namespace HelloDotNetConsole;

public static class L10FunctionsClassMethods {
    /**
     * Чего-то там печатает
     */
    public static void Print(string word) {
        Console.WriteLine(word);
    }


    public static void Run() {
        Print("Hello");
        Print("World");
        Print("!");
        // Создание подключения
    }
}