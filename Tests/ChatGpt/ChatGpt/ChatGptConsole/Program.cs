namespace ChatGptConsole;

public static class Program
{
    public static async Task Main()
    {
        var api = new OpenAI_API.OpenAIAPI("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");
        var result = await api.Completions.GetCompletion("One Two Three One Two");
        Console.WriteLine(result);
        // should print something starting with "Three"
    }
}

