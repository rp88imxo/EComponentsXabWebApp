namespace EComponents.Services.Mail
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string toEmailAddress, string subject, string mailBody, string fromName);
    }
}