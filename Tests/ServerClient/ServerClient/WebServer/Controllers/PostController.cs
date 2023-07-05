using Microsoft.AspNetCore.Mvc;
using static WebServer.Helper;

namespace WebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
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

        try { amount = Convert.ToDecimal(Request.Form["amount"]); } 
        catch { Console.WriteLine("Can't convert amount!"); }

        // string? address = _configuration.GetValue<string>($"Devices:{id}");

        string? address = _configuration
            .GetSection("DevicesList")
            .Get<List<DevicesListItem>>()
            .Find(i => i.Id == id)?
            .Address;
  
        if (amount != 0 && address != null)
        {
            Task task = Task.Run(() => Send(id, amount, address));
            queueManager.AddTask(id, task);
        }

        return Ok("");
    }
}

public class DevicesListItem
{
    public string Id { get; set; } = default!;
    public string Address { get; set; } = default!;
}