using Microsoft.AspNetCore.Mvc;
using static WebServer.Helper;
using static WebServer.Settings;

namespace WebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpPost(Name = "Home")]
    public IActionResult Get()
    {
        int id = 0;
        try { id = Convert.ToInt32(Request.Form["id"]);  } catch { Console.WriteLine("Can't convert id!"); }

        decimal amount = 0;
        try { amount = Convert.ToDecimal(Request.Form["amount"]);  } catch { Console.WriteLine("Can't convert amount!"); }

        Addresses.TryGetValue(id, out string? address);

        if (address != null)
        {
            AddDbTask(id, address, amount);
        }

        return Ok("Ok");
    }
}