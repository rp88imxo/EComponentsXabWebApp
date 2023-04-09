using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComponents.Services.Mail
{
    public class MailSettingsData
    {
        public MailSettingsData()
        {

        }

        public MailSettingsData(string host, string mail, string password, int port)
        {
            Host = host;
            Mail = mail;
            Password = password;
            Port = port;
        }

        public string Host { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}
