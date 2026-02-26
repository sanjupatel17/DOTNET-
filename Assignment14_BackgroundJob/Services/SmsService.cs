using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Assignment14_BackgroundJob.Services
{
    public class SmsService : ISmsService
    {
        private readonly ILogger<SmsService> _logger;

        public SmsService(ILogger<SmsService> logger)
        {
            _logger = logger;
        }

        public Task SendSmsAsync(string number, string message)
        {
            _logger.LogInformation($"Mock SMS sent to {number}: {message}");
            return Task.CompletedTask;
        }
    }
}