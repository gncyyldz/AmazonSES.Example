using AmazonSES.Example.Models;
using AmazonSES.Example.Services.Abstractions;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace AmazonSES.Example.Services
{
    public class MailService(IConfiguration configuration) : IMailService
    {
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            MimeMessage email = new();
            email.From.Add(new MailboxAddress("Gençay YILDIZ", configuration["MailSettings:From"]));
            email.To.Add(MailboxAddress.Parse(mailRequest.To));
            email.Subject = mailRequest.Subject;

            BodyBuilder bodyBuilder = new();
            bodyBuilder.HtmlBody = mailRequest.Body;
            email.Body = bodyBuilder.ToMessageBody();

            using SmtpClient smtpClient = new();
            await smtpClient.ConnectAsync(configuration["MailSettings:Host"], int.Parse(configuration["MailSettings:Port"]), SecureSocketOptions.StartTls);
            await smtpClient.AuthenticateAsync(configuration["MailSettings:SMTP:Username"], configuration["MailSettings:SMTP:Password"]);
            await smtpClient.SendAsync(email);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
