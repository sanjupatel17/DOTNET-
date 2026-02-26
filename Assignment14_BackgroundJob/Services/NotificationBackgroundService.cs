using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment14_BackgroundJob.Services
{
    public class NotificationBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<NotificationBackgroundService> _logger;

        public NotificationBackgroundService(
            IServiceProvider serviceProvider,
            ILogger<NotificationBackgroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Background Service Started");

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                var smsService = scope.ServiceProvider.GetRequiredService<ISmsService>();

                try
                {
                    _logger.LogInformation("Running Scheduled Job at {time}", DateTime.Now);

                    await emailService.SendEmailAsync(
                        "receiver@gmail.com",
                        "Scheduled Background Email",
                        "This email is sent every 1 minute.");

                    await smsService.SendSmsAsync(
                        "9999999999",
                        "Scheduled SMS sent successfully.");

                    _logger.LogInformation("Scheduled Job Completed");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in background job");
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}