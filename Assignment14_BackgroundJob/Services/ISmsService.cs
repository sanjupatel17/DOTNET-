using System.Threading.Tasks;

namespace Assignment14_BackgroundJob.Services
{
    public interface ISmsService
    {
        Task SendSmsAsync(string number, string message);
    }
}