using APITest.Classes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace APITest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("member")]
        [HttpGet]
        public string Hallo()
        {
            return "Hallo!";
        }

        [Route("member/{name}")]
        [HttpGet]
        public string HalloWithNumber(string name)
        {
            return "Hallo, " + name + "!";
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            string AName = user.Username;

            if (AName != "")
            {
                return Ok("false");
            }
            else
            {
                return Ok("true");
            }
        }
    }
}