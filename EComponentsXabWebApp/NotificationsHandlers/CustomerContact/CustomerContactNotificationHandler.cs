using EComponents.Services.Mail;
using EComponents.Services.Notifications.Contact;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EComponentsXabWebApp.NotificationsHandlers.CustomerContact
{
    public class CustomerContactNotificationHandler : INotificationHandler<CustomerContactNotification>
    {
        private readonly IEmailService emailService;
        private readonly ILogger<CustomerContactNotificationHandler> logger;

        private readonly string emailTo = "hub@ecomponentsxab.com";
        private readonly string fromEmail = "hub@ecomponentsxab.com";

        public CustomerContactNotificationHandler(
            IEmailService emailService,
            ILogger<CustomerContactNotificationHandler> logger
            )
        {
            this.emailService = emailService;
            this.logger = logger;
        }

        public async Task Handle(CustomerContactNotification notification, CancellationToken cancellationToken)
        {
            var customerData = notification.CustomerContact;

            var result = await emailService.SendEmailAsync(
                emailTo,
                $"Сообщение от {customerData.CustomerName} | {customerData.CustomerEmail}",
                customerData.Message,
                fromEmail
            );

            if (result)
            {
                logger.LogInformation("Sent email customer contact!");
            }
            else
            {
                logger.LogError("Couldn't send email customer contact!");
            }
        }
    }
}
