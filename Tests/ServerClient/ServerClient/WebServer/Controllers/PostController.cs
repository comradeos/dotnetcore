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

        try { amount = Convert.ToDecimal(Request.Form["amount"]);  } catch { Console.WriteLine("Can't convert amount!"); }

        string? address = _configuration.GetValue<string>($"Devices:{id}");

        if (amount != 0 && address != null)
        {
            // AddDbSenderTask(id, address, amount);
            // return Ok($"Db sender task added!");

            Task task = Task.Run(() => Send(amount, address));
            queueManager.AddTask(id, task);
        }
        
        return Ok("");
    }
}