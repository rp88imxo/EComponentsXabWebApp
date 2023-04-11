using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComponents.Core.Domain.CustomerContact
{
    public class CustomerContact
    {
        public string CustomerName { get; set; } = string.Empty;

        public string CustomerEmail { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}
