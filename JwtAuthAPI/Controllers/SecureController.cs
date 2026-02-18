using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SecureController : ControllerBase
{
    [HttpGet]
    public IActionResult GetSecureData()
    {
        return Ok("This is secured data");
    }
}
