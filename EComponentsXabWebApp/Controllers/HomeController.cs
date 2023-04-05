using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EComponentsXabWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult ErrorNotFound()
        {
            return View();
        }
    }
}