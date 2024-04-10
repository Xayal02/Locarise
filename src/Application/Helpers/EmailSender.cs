using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Xml.Linq;

namespace Application.Helpers
{
    public static class EmailSender
    {
        public static void SendEmailTo(string userEmailAddress, string emailSubject, string body)
        {
            string mailFrom = new ConfigurationBuilder().AddJsonFile($"appsettings.json").Build().GetSection("Contact")["EmailAddress"];
            string password = new ConfigurationBuilder().AddJsonFile($"appsettings.json").Build().GetSection("Contact")["EmailAddressPassword"];


            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(mailFrom);
                mail.To.Add(userEmailAddress);
                mail.Subject = emailSubject;
                mail.Body = $"<h3>{body}</h3>";
                mail.IsBodyHtml = true;


                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(mailFrom, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

        }
    }
}
