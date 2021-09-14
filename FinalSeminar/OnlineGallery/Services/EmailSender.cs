using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using OnlineGallery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OnlineGallery.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmailSender(IOptions<EmailSettings> emailSettings, IWebHostEnvironment webHostEnvironment)
        {
            _emailSettings = emailSettings.Value;
            _webHostEnvironment = webHostEnvironment;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
                EnableSsl = _emailSettings.EnableSSL
            };
            return client.SendMailAsync(new MailMessage(_emailSettings.Username, email, subject, message) { IsBodyHtml = true });
        }

        public Task SendEmailContactAsync(string email, string subject, string message)
        {
            var client = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
                EnableSsl = _emailSettings.EnableSSL
            };
            return client.SendMailAsync(new MailMessage(email, _emailSettings.Username, subject, message) { IsBodyHtml = true });
        }
    }
}
