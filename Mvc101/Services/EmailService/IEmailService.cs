using Mvc101.Models;

namespace Mvc101.Services.EmailService
{
    public interface IEmailService
    {
        Task SendMailAsync(MailModel model);
    }
}
