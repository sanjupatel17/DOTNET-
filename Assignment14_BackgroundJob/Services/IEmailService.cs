using System.Threading.Tasks;

namespace Assignment14_BackgroundJob.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}