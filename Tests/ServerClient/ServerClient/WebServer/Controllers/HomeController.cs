using Microsoft.AspNetCore.Mvc;
using static WebServer.Helper;
using Microsoft.Data.Sqlite;
using System.Net;

namespace WebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpPost(Name = "Home")]
    public IActionResult Get()
    {
        // Console.WriteLine(Request.Form["amount"]);
        // Console.WriteLine(Request.Form["id"]);

        int id = 0;
        try { id = Convert.ToInt32(Request.Form["id"]);  } catch { Console.WriteLine("Can't convert id!"); }

        decimal amount = 0;
        try { amount = Convert.ToDecimal(Request.Form["amount"]);  } catch { Console.WriteLine("Can't convert amount!"); }

        string address = Request.Form["address"];

        AddDbTask(id, address, amount);

        return Ok("Ok");
    }
}