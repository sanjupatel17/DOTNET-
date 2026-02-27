using Microsoft.AspNetCore.Mvc;

namespace Assignment16.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration _config;

        public TestController(IConfiguration config)
        {
            _config = config;
        }

        // ✅ Existing endpoint
        [HttpGet]
        public IActionResult Get()
        {
            var message = _config["AppSettings:Message"];
            return Ok(message);
        }

        // ✅ ADD THIS METHOD (Error Test)
        [HttpGet("error")]
        public IActionResult Error()
        {
            throw new Exception("Test Exception");
        }
    }
}