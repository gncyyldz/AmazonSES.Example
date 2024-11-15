using Amazon.SimpleEmail;
using AmazonSES.Example.Models;
using AmazonSES.Example.Services;
using AmazonSES.Example.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMailService, MailService>();

builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonSimpleEmailService>();

builder.Services.AddSingleton<ISESService, SESService>();

var app = builder.Build();

#region SMTP
//app.MapPost("/send-mail", async (MailRequest mailRequest, IMailService mailService)
//    => await mailService.SendEmailAsync(mailRequest));
#endregion
#region AWS SDK
app.MapPost("/send-mail", async (MailRequest mailRequest, ISESService sesService)
    => await sesService.SendEmailAsync(mailRequest));
#endregion

app.Run();
