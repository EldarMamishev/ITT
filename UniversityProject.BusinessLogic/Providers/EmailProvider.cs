using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Providers.Interfaces;

namespace UniversityProject.BusinessLogic.Providers
{
    public class EmailProvider : IEmailProvider
    {
        #region Properties
        private readonly string _nameCompany;
        private readonly string _host;
        private readonly int _port;
        private readonly bool _useSsl;
        private readonly string _senderEmail;
        private readonly string _senderPassword;
        #endregion

        #region Constructors
        public EmailProvider(IConfiguration configuration)
        {
            IConfigurationSection smtpConfiguration = configuration.GetSection("SmtpConfiguration");

            _nameCompany = smtpConfiguration?["CompanyName"];
            _senderEmail = smtpConfiguration?["Email"];
            _senderPassword = smtpConfiguration?["Password"];
            _host = smtpConfiguration?["Host"];
            _port = Convert.ToInt32(smtpConfiguration?["Port"]);
            _useSsl = Convert.ToBoolean(smtpConfiguration?["UseSsl"]);
        }
        #endregion

        #region Public Methods
        public async Task SendMessage(IEnumerable<string> recipientEmailList, string subject, string body)
        {
            using (var client = new SmtpClient())
            {
                client.Host = _host;
                client.Port = _port;
                client.Credentials = new NetworkCredential(_senderEmail, _senderPassword);
                client.EnableSsl = _useSsl;

                var emailMessage = new MailMessage();

                emailMessage.From = new MailAddress(_senderEmail, _nameCompany);

                foreach (string recipientEmail in recipientEmailList)
                {
                    emailMessage.To.Add(new MailAddress(recipientEmail, string.Empty));
                }

                emailMessage.Subject = $"{_nameCompany}: {subject}";
                emailMessage.IsBodyHtml = true;
                emailMessage.Body = body;

                await client.SendMailAsync(emailMessage);
            }
        }

        public async Task SendMessage(string recipientEmail, string subject, string body)
        {
            var recipientEmailList = new HashSet<string>();
            recipientEmailList.Add(recipientEmail);

            await SendMessage(recipientEmailList, subject, body);
        }
        #endregion
    }
}
