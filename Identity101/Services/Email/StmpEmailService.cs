﻿using System.Net;
using System.Net.Mail;
using System.Text;
using Identity101.Models;
using Identity101.Models.Configuration;
using Microsoft.Extensions.Configuration;

namespace Identity101.Services.Email;

public class SmtpEmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailSettings EmailSettings { get; }
    public SmtpEmailService(IConfiguration configuration)
    {
        _configuration = configuration;
        this.EmailSettings = _configuration.GetSection("GmailSettings").Get<EmailSettings>();

    }
   

    public Task SendMailAsync(MailModel model)
    {
        var mail = new MailMessage { From = new MailAddress(this.EmailSettings.SenderMail) };

        foreach (var c in model.To)
        {
            mail.To.Add(new MailAddress(c.Adress, c.Name));
        }

        foreach (var cc in model.Cc)
        {
            mail.CC.Add(new MailAddress(cc.Adress, cc.Name));
        }
        foreach (var cc in model.Bcc)
        {
            mail.Bcc.Add(new MailAddress(cc.Adress, cc.Name));
        }

        if (model.Attachs is { Count: > 0 })
        {
            foreach (var attach in model.Attachs)
            {
                //mail.Attachments.Add(new Attachment(attach));
                //mail.Attachments.Add(new Attachment(attach));
                var fileStream = attach as FileStream;
                var info = new FileInfo(fileStream.Name);

                mail.Attachments.Add(new Attachment(attach, info.Name));
            }
        }

        mail.IsBodyHtml = true;
        mail.BodyEncoding = Encoding.UTF8;
        mail.SubjectEncoding = Encoding.UTF8;
        mail.HeadersEncoding = Encoding.UTF8;

        mail.Subject = model.Subject;
        mail.Body = model.Body;

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        var smtpClient = new SmtpClient(this.EmailSettings.Smtp, this.EmailSettings.SmtpPort)
        {
            Credentials = new NetworkCredential(this.EmailSettings.SenderMail, this.EmailSettings.Password),
            EnableSsl = true
        };
        return smtpClient.SendMailAsync(mail);
    }
}
