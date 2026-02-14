using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/my_service")]
public class MyServiceController : ControllerBase
{
    private readonly IMyService _myService;

    public MyServiceController(IMyService myService)
    {
        _myService = myService;
    }

    [HttpGet()]
    public IActionResult Get(int id)
    {
        var result = _myService.GetName();
        return Ok(result);
    }
}
