using AmazonSES.Example.Models;

namespace AmazonSES.Example.Services.Abstractions
{
    public interface ISESService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
