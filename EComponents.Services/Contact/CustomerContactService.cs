using EComponents.Core.Domain.CustomerContact;
using EComponents.Services.Notifications.Contact;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComponents.Services.Contact
{
    public class CustomerContactService : ICustomerContactService
    {
        private readonly IMediator mediator;

        public CustomerContactService(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task HandleCustomerContactAsync(CustomerContact customerContact)
        {
            await mediator.Publish(new CustomerContactNotification(customerContact));
        }
    }
}
