using Microsoft.AspNetCore.Mvc;

namespace Confy.Api.Controllers
{
    [Route("api/home")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get() => Ok("Confy works!");
    }
}
