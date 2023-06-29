using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private static readonly HttpClient client = new HttpClient();

    [HttpPost(Name = "Home")]
    public async Task<IActionResult> Get()
    {
        Console.WriteLine(Request.Form["amount"]);
        Console.WriteLine(Request.Form["id"]);

        var responseString = await client.GetStringAsync("http://127.0.0.2:8888/");
        Console.WriteLine($"RESPONSE FROM {responseString}");
        return Ok("a");
    }
}