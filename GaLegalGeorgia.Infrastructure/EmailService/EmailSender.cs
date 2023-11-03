using GaLegalGeorgia.Application.Contracts.Email;
using GaLegalGeorgia.Application.Models.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly string serviceEmail;
        private readonly string SendgridApiKey;
        private readonly string currentWebsiteUrl;
        public EmailSender(IConfiguration configuration) {

            serviceEmail = configuration.GetSection("ServiceEmail")?.Value;
            SendgridApiKey = configuration.GetSection("SendgridApiKey")?.Value?? "test";
        }

        public async Task<bool> SendPasswordResetEmail(string token, string recipientEmail)
        {
            var htmlContent = $"<strong>To reset your password follow the <a href='{currentWebsiteUrl}pw-recovery?token={token}'>link</a> </strong>";
            var result = await SendEmail("Forgot Password", recipientEmail, htmlContent);
            return result;
        }

        private async Task<bool> SendEmail(string emailSubject, string recipientEmail, string htmlContent, string plainTextContent = null)
        {
            var client = new SendGridClient(SendgridApiKey);
            var from = new EmailAddress(serviceEmail, "GaLegalGeorgia");
            var subject = emailSubject;
            var to = new EmailAddress(recipientEmail, "Givi");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return response.IsSuccessStatusCode;
        }

    }
}
