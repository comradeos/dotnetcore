using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using static WebServer.Helper;

namespace WebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly AppDevices appDevices = new();

    private readonly IConfiguration _configuration;

    public PostController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost(Name = "Post")]
    public IActionResult Post()
    {
        string id = Request.Form["id"];
        decimal amount = 0;

        try { amount = Convert.ToDecimal(Request.Form["amount"]);  } catch { Console.WriteLine("Can't convert amount!"); }

        // string? address = _configuration.GetValue<string>($"Devices:{id}");
        
        Console.WriteLine($"appDevices.Count: {appDevices?.devices?.Count}");

        DevicesListItem? devicesListItem = appDevices?.devices?.Find(i => i.Id == id);
        string? address = devicesListItem?.Address;

        if (amount != 0 && address != null)
        {
            // AddDbSenderTask(id, address, amount);
            // return Ok($"Db sender task added!");

            Task task = Task.Run(() => Send(id, amount, address));
            queueManager.AddTask(id, task);
        }
        
        return Ok("");
    }
}

public class DevicesListItem
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    [JsonPropertyName("address")]
    public string? Address { get; set; }
}

public class AppDevices
{
    private static readonly string SettingsPath = "appdevices.json";

    public List<DevicesListItem>? devices = new();

    public AppDevices()
    {
        using (StreamReader streamReader = new(SettingsPath))
        {
            devices = JsonSerializer.Deserialize<List<DevicesListItem>>(streamReader.ReadToEnd());
        }

        if (devices == null)
        {
            Console.WriteLine("devices == null");
            Environment.Exit(0);
        }

        if (devices?.Count == 0)
        {
            Console.WriteLine("devices?.Count == 0");
            Environment.Exit(0);
        }
    }
}