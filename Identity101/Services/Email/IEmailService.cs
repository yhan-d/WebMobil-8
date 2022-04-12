using Identity101.Models;

namespace Identity101.Services.Email

{
    public interface IEmailService
    {
        Task SendMailAsync(MailModel model);
    }
}
