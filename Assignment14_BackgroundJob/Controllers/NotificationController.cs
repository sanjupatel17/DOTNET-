using Assignment14_BackgroundJob.Models;
using Assignment14_BackgroundJob.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Assignment14_BackgroundJob.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(
            IEmailService emailService,
            ISmsService smsService,
            ILogger<NotificationController> logger)
        {
            _emailService = emailService;
            _smsService = smsService;
            _logger = logger;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] SendEmailRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _emailService.SendEmailAsync(
                    request.ToEmail,
                    request.Subject,
                    request.Body);

                await _smsService.SendSmsAsync(
                    "9999999999",
                    $"Email sent to {request.ToEmail}");

                _logger.LogInformation("Manual email sent to {email}", request.ToEmail);

                return Ok("Email Sent Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
                return StatusCode(500, ex.Message);
            }
        }
    }
}