using EComponents.Services.Mail;
using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace EComponentsXabWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService emailService;

        public HomeController(
            ILogger<HomeController> logger,
            IEmailService emailService)
        {
            _logger = logger;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public async Task<IActionResult> SendEmail([EmailAddress]string to, string subject, string body)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await emailService.SendEmailAsync(
                    to,
                    subject,
                    body,
                     "EComponents");

                if (result)
                {
                    return Ok("Ok");
                }
                else
                {
                    return BadRequest(result);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public IActionResult ErrorNotFound()
        {
            return View();
        }
    }
}