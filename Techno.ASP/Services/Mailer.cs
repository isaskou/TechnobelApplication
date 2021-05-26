using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techno.ASP.Services
{
    public class Mailer
    {
        private readonly IConfiguration _config;
        private readonly SmtpClient _client;

        public Mailer(IConfiguration config, SmtpClient client)
        {
            _config = config;
            _client = client;
        }

        public bool Send(string destinataire, string subject, string content)
        {
            IConfiguration section = _config.GetSection("Smtp");

            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("Technobel", section.GetValue<string>("Email")));

            message.To.Add(new MailboxAddress(destinataire, destinataire));

            message.Subject = subject;

            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = content;
            message.Body = builder.ToMessageBody();

            try
            {
                _client.Connect(section.GetValue<string>("Host"), section.GetValue<int>("Port"), false);

                _client.Authenticate(section.GetValue<string>("Email"), section.GetValue<string>("Password"));

                _client.Send(message);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
