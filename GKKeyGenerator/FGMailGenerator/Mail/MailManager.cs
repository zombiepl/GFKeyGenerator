using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using FGMailGenerator.IMail;

namespace FGMailGenerator.Mail
{
    public class MailManager : IMailManager//uzupeła pola i podpina załącznik
    {
        private MailMessage _mailMessage;
        private SmtpClient _client;
        public bool ssl = true;
                                                                //string body,
        public MailManager(string host, int port, string subject, string body, string from, string password, string emailRecipient)
        {                           //
            Fill(host, port, subject, body, from,  password, emailRecipient);
            
        }

        public MailManager(string host, int port, string subject, string body, string from, string password, string emailRecipient, string path)
        {
            Fill(host, port, subject, body, from, password, emailRecipient);
            _mailMessage.Attachments.Add(new Attachment(path));
        }

        public MailManager(string host, int port, string subject, string body, string from, string password, string emailRecipient, MemoryStream ms, string fileName)
        {
            Fill(host, port, subject, body, from, password, emailRecipient);
            _mailMessage.Attachments.Add(new Attachment(ms, fileName));
        }

        public void Fill(string host, int port, string subject, string body, string from, string password, string emailRecipient)
        {
            _client = new SmtpClient(host, port);
            _client.UseDefaultCredentials = false;
            NetworkCredential nk = new NetworkCredential(from, password);
            _client.Credentials = nk;
            _client.EnableSsl = ssl;
            _client.DeliveryMethod = SmtpDeliveryMethod.Network;

            _mailMessage = new MailMessage(from, emailRecipient);
            _mailMessage.Subject = subject;
            _mailMessage.Body = body;
            _mailMessage.IsBodyHtml = true;
            _mailMessage.Priority = MailPriority.Normal;
            _mailMessage.BodyEncoding = Encoding.UTF8;
        }

        public void Send()
        {
            _client.Send(_mailMessage);
        }

    }
}