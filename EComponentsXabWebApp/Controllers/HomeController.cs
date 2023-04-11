using EComponents.Core.Domain.CustomerContact;
using EComponents.Services.Contact;
using EComponents.Services.Mail;
using EComponentsXabWebApp.ViewModels.Contact;
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
        private readonly ICustomerContactService customerContactService;

        public HomeController(
            ILogger<HomeController> logger,
            IEmailService emailService,
            ICustomerContactService customerContactService)
        {
            _logger = logger;
            this.emailService = emailService;
            this.customerContactService = customerContactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(CustomerContactViewModel customerContactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var contactData = new CustomerContact()
            {
                CustomerName = customerContactViewModel.CustomerName,
                CustomerEmail = customerContactViewModel.CustomerEmail,
                Message = customerContactViewModel.Message
            };

            await customerContactService.HandleCustomerContactAsync(contactData);

            return View("ContactSuccess");
        }

        public async Task<IActionResult> SendEmail([EmailAddress] string to, string subject, string body)
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