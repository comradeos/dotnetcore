using Microsoft.AspNetCore.Mvc;
using static TempApi.Helper;

namespace WebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public TestController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost(Name = "Test")]
    public IActionResult Post()
    {
        int id = 0;

        string del = Request.Form["del"];

        string str = Request.Form["str"];

        try { id = Convert.ToInt32(Request.Form["id"]); } catch { Console.WriteLine("Can't convert id!"); }

        if (id != 0)
        {
            // tasks.Enqueue(Task.Factory.StartNew(() => { SomeAction(id); }));
            // tasks.Enqueue(new Task(() => { SomeAction(id); }));
        }

        if (!string.IsNullOrEmpty(str))
        {
            strings.Enqueue(str);
        }

        if (del == "yes")
        {
            strings.Dequeue();
        }

        return Ok("Ok");
    }
}