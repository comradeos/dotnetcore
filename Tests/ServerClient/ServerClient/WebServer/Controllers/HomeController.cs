using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.IO;
using System.Reflection;

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

        string responseString = await client.GetStringAsync("http://127.0.0.1:8888/");

        Console.WriteLine($"RESPONSE FROM {responseString}");

        return Ok("a");
    }
}