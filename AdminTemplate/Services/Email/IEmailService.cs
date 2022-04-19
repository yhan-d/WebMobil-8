using AdminTemplate.Models;

namespace AdminTemplate.Services.Email

{
    public interface IEmailService
    {
        Task SendMailAsync(MailModel model);
    }
}
