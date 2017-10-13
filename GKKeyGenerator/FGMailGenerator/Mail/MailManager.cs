using System.IO;
using System.Net.Mail;
using FGMailGenerator.IMail;

namespace FGMailGenerator.Mail
{
    public class MailManager : IMailManager//uzupeła pola i podpina załącznik
    {
        private MailMessage _mailMessage;
        private SmtpClient _client;

        public MailManager(string host, int port, string subject, string body, string emailReceiver, string emailRecipient)
        {
            Fill(host, port, subject, body, emailReceiver, emailRecipient);
        }

        public MailManager(string host, int port, string subject, string body, string emailReceiver, string emailRecipient, string path)
        {
            Fill(host, port, subject, body, emailReceiver, emailRecipient);
            _mailMessage.Attachments.Add(new Attachment(path));
        }

        public MailManager(string host, int port, string subject, string body, string emailReceiver, string emailRecipient, MemoryStream ms, string fileName)
        {
            Fill(host, port, subject, body, emailReceiver, emailRecipient);
            _mailMessage.Attachments.Add(new Attachment(ms, fileName));
        }

        private void Fill(string host, int port, string subject, string body, string emailReceiver, string emailRecipient)
        {
            _client = new SmtpClient();
            _client.Port = port;
            _client.DeliveryMethod = SmtpDeliveryMethod.Network;
            _client.UseDefaultCredentials = false;
            _client.Host = host;

            _mailMessage = new MailMessage(emailReceiver, emailRecipient);
            _mailMessage.Subject = subject;
            _mailMessage.Body = body;
        }

        public void Send()
        {
            _client.Send(_mailMessage);
        }

    }
}