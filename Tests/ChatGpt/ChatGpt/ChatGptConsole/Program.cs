namespace ChatGptConsole;

public static class Program
{
    public static async Task Main()
    {
        var api = new OpenAI_API.OpenAIAPI("key");
        var result = await api.Completions.GetCompletion("One Two Three One Two");
        Console.WriteLine(result);
        // should print something starting with "Three"
    }
}

