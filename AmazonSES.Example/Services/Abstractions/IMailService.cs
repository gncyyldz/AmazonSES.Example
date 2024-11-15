using AmazonSES.Example.Models;

namespace AmazonSES.Example.Services.Abstractions
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
