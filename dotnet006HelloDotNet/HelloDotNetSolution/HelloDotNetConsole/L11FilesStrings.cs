namespace HelloDotNetConsole;

public static class L11FilesStrings
{
    public static void Run()
    {
        var word = "abc";
        word += "def";
        Console.WriteLine(word);  // abcdef
        Console.WriteLine(word.Length);  // 6
    }
}