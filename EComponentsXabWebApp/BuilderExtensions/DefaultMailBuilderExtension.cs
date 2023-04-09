using EComponents.Services.Mail;

namespace EComponentsXabWebApp.BuilderExtensions
{
    public static class DefaultMailBuilderExtension
    {
        public static void AddDefaultMailService(this WebApplicationBuilder webApplicationBuilder)
        {
            var mailSettings = new MailSettingsData();
            webApplicationBuilder.Configuration.Bind("MailSettingsData", mailSettings);
            webApplicationBuilder.Services
                .AddFluentEmail(mailSettings.Mail)
                .AddMailKitSender(new FluentEmail.MailKitSmtp.SmtpClientOptions
                {
                    Server = mailSettings.Host,
                    Port = mailSettings.Port,
                    Password = mailSettings.Password,
                    UseSsl = true,
                    User = mailSettings.Mail,
                    RequiresAuthentication = true
                });
        }
    }
}
