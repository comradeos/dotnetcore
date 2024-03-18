using System.Text.Json;

namespace ConsoleApp.Modules;

public class DictionaryJsonEncode
{
    public static void Test()
    {
        Dictionary<string, string> dictionary = new()
        {
            {"key1", "value1"},
            {"key2", "value2"}
        };

        string json = JsonSerializer.Serialize(dictionary);
        Console.WriteLine(json);
    }
}