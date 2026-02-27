using Microsoft.AspNetCore.Mvc;

namespace Assignment16.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSecret()
        {
            var secret =
                Environment.GetEnvironmentVariable("MySecretKey");

            return Ok($"Secret Loaded: {secret}");
        }
    }
}