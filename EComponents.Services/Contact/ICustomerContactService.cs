using EComponents.Core.Domain.CustomerContact;

namespace EComponents.Services.Contact
{
    public interface ICustomerContactService
    {
        Task HandleCustomerContactAsync(CustomerContact customerContact);
    }
}