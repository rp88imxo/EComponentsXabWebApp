using EComponents.Core.Domain.CustomerContact;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComponents.Services.Notifications.Contact
{
    public class CustomerContactNotification : INotification
    {
        public CustomerContact CustomerContact { get; }

        public CustomerContactNotification(CustomerContact customerContact)
        {
            CustomerContact = customerContact;
        }

    }
}
