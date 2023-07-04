using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AppClient;

public class Program
{
    private static readonly Settings settings = new();
    private static readonly HttpListener listener = new();
    private static readonly string startMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Program '{settings.Name}' started!";

    public static async Task Main()
    {
        Console.WriteLine(startMessage);

        listener.Prefixes.Add(settings.Address);
        listener.Start();

        while (true)
        {
            HttpListenerContext context = await listener.GetContextAsync();

            string? amount = context.Request.QueryString["amount"];

            byte[] outputBytes = Encoding.UTF8.GetBytes("Ok");

            if (amount != null)
            {
                outputBytes = Encoding.UTF8.GetBytes($"Received {amount} UAH!");
            }

            string outputString = Encoding.UTF8.GetString(outputBytes);

            context.Response.StatusCode = 200;
            context.Response.KeepAlive = false;
            context.Response.ContentLength64 = outputBytes.Length;

            Stream output = context.Response.OutputStream;

            output.Write(outputBytes, 0, outputBytes.Length);
            context.Response.Close();

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (amount != null)
            {
                Console.WriteLine($"[{time}] {outputString}");
            }
        }
    }
}

public class SettingsModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;
    [JsonPropertyName("address")]
    public string Address { get; set; } = default!;
}

public class Settings
{
    private static readonly string SettingsPath = "../../../settings.json";
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;

    public Settings()
    {
        SettingsModel? settingsModel;

        using (StreamReader streamReader = new(SettingsPath))
        {
            settingsModel = JsonSerializer.Deserialize<SettingsModel>(streamReader.ReadToEnd());
        }

        if (string.IsNullOrEmpty(settingsModel?.Name))
        {
            Console.WriteLine("settings.json error: 'name' not found");
            Environment.Exit(0);
        }

        if (string.IsNullOrEmpty(settingsModel?.Address))
        {
            Console.WriteLine("settings.json error: 'address' not found");
            Environment.Exit(0);
        }

        Name = settingsModel.Name;
        Address = settingsModel.Address;
    }
}