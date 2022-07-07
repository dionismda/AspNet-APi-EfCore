using AspNet_Api_EfCore.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_Api_EfCore.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("HealthCheck")]
        [ApiKey]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
