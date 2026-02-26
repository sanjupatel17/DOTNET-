using System.ComponentModel.DataAnnotations;

namespace Assignment14_BackgroundJob.Models
{
    public class SendEmailRequest
    {
        [Required]
        [EmailAddress]
        public string? ToEmail { get; set; }

        [Required]
        public string? Subject { get; set; }

        [Required]
        public string? Body { get; set; }
    }
}