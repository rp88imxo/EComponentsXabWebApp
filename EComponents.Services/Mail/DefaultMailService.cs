using FluentEmail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComponents.Services.Mail
{
    public class DefaultMailService : IEmailService
    {
        private readonly IFluentEmailFactory fluentEmailFactory;

        public DefaultMailService(
            IFluentEmailFactory fluentEmailFactory
            )
        {
            this.fluentEmailFactory = fluentEmailFactory;
        }

        public async Task<bool> SendEmailAsync(string toEmailAddress, string subject, string mailBody, string fromName)
        {
            var email = fluentEmailFactory
                 .Create()
                 .To(toEmailAddress)
                 .Subject(subject)
                 .Body(mailBody)
                 .SetFrom("hub@ecomponentsxab.com", fromName);

            var result = await email.SendAsync();

            if (result.Successful)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
