using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.DTO.Email;
using Ecom.Core.Services;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Ecom.Infrastructure.Repository.Services
{
    public class EmailService : IEmailService
    {
        //private readonly IConfiguration configuration;

        //public EmailService(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}
        //public async  Task sendEmail(EmailDTO emailDTO)
        //{
        //    MimeMessage message = new MimeMessage();
        //    //message.From = configuration["EmailSettings:From"].Split(",").Select(x => MailboxAddress.Parse(x)).ToList();
        //    message.From.Add( new MailboxAddress("My App",configuration["EmailSettings:From"]));
        //    message.Subject = emailDTO.Subject;
        //    message.To.Add(new MailboxAddress(emailDTO.TO, emailDTO.TO));
        //    message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        //    {
        //        Text = emailDTO.Content
        //    };
        //    using(var smtp = new MailKit.Net.Smtp.SmtpClient())
        //    {
        //        try
        //        {
        //             await  smtp.ConnectAsync(configuration["EmailSettings:Host"],
        //                int.Parse(configuration["EmailSettings:Port"]),
        //                true);
        //              await smtp.AuthenticateAsync(configuration["EmailSettings:Username"],
        //                configuration["EmailSettings:Password"]);

        //            await smtp.SendAsync(message);


        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            smtp.Disconnect(true);
        //            smtp.Dispose();
        //        }
        //    }
        //}

        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task sendEmail(EmailDTO emailDTO)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Ecom App", _config["EmailSettings:From"]));
            email.To.Add(new MailboxAddress("", emailDTO.TO));
            email.Subject = emailDTO.Subject;

            email.Body = new TextPart("html") { Text = emailDTO.Content };

            using var client = new MailKit.Net.Smtp.SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_config["EmailSettings:From"], _config["EmailSettings:Password"]);
            await client.SendAsync(email);
            await client.DisconnectAsync(true);
        }

    }

}
