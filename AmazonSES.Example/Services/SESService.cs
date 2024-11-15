using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using AmazonSES.Example.Models;
using AmazonSES.Example.Services.Abstractions;

namespace AmazonSES.Example.Services
{
    public class SESService(IConfiguration configuration, IAmazonSimpleEmailService amazonSimpleEmailService) : ISESService
    {
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            Body mailBody = new(new Content(mailRequest.Body));
            Message message = new(new Content(mailRequest.Subject), mailBody);
            Destination destination = new([mailRequest.To]);
            SendEmailRequest request = new(configuration["MailSettings:From"], destination, message);
            SendEmailResponse response = await amazonSimpleEmailService.SendEmailAsync(request);
            Console.WriteLine(response.HttpStatusCode);
        }
    }
}
