using Microsoft.AspNetCore.Mvc;

namespace GeneralApi.Controllers;

[ApiController]
[Route("404")]
public class NotFoundController : ControllerBase
{
    [HttpGet]
    public ActionResult<ResponseModel> Handler()
    {
        ResponseModel response = new ResponseModel
        {
            Message = "Not Found!"
        };
        
        return Ok(response);
    }
}

public class ResponseModel
{
    public string Message { get; set; } = default!;
}