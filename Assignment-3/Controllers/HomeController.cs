using Microsoft.AspNetCore.Mvc;
using Assignment_3.Services;

namespace Assignment_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IConfiguration _configuration;

        // Inject BOTH service and configuration
        public HomeController(
            IMessageService messageService,
            IConfiguration configuration)
        {
            _messageService = messageService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // Read values from appsettings
            ViewBag.AppName = _configuration["AppSettings:AppName"];
            ViewBag.Environment = _configuration["AppSettings:Environment"];

            // Service message
            ViewBag.ServiceMessage = _messageService.GetMessage();

            return View();
        }
    }
}
