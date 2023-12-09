using Microsoft.AspNetCore.Mvc;
using GeneralApi.Database;
using GeneralApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeneralApi.Controllers
{
    [ApiController]
    [Route("hello")]
    public class HelloWorldController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;

        public HelloWorldController(MyDbContext context)
        {
            _myDbContext = context;
        }

        [HttpGet("{id:int?}")]
        public ActionResult<MyData> Get()
        {
            /* Create new entry in database
            MyData myData = new()
            {
                Id = 1,
                Name = "John Doe",
                Phone = "123456789"
            };
            _myDbContext.MyData.Add(myData);
            _myDbContext.SaveChanges();
            */

            /* Find by Id
            MyData myData = _myDbContext.MyData.Find(1);
            */

            // Find by Raw SQL Query
            MyData? myData = _myDbContext.MyData.FromSqlRaw("SELECT * FROM MyData WHERE Id = {0}", 1).FirstOrDefault();

            return Ok(myData);
        }
    }
}