using Microsoft.Extensions.Options;
using SolveBank.Infrastructure.ExternalServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SolveBank.Entities.Models;

namespace SolveBank.Infrastructure.ExternalServices.Services
{
    public class EmailService : IEmailRepository
    {
        private readonly EmailConfiguracao _emailSettings;
        public EmailService(IOptions<EmailConfiguracao> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendToEmail(string body, string emailDestination)
        {
            var sendMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.EmailFromAddress),
                Subject = "SolveBank, Seu código de acesso chegou",
                Body = body,
                IsBodyHtml = true
            };
            sendMessage.To.Add(emailDestination);

            using (var smtpClient = new SmtpClient(_emailSettings.ServerSmtp, _emailSettings.Port))
            {
                smtpClient.Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password);
                smtpClient.EnableSsl = _emailSettings.EnableSsl;
                await smtpClient.SendMailAsync(sendMessage);
            }
        }
    }
}
