using System;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Business.Providers
{
    public class EmailHelper
    {
        public async static Task SendAsync(EmailConfig _emailConfig, MailMessage message, bool isHtml = false, bool enableSsl = false)
        {
            message.IsBodyHtml = isHtml;
            message.Priority = MailPriority.High;
            using (var smtp = new SmtpClient())
            {
                smtp.EnableSsl = enableSsl;
                await smtp.SendMailAsync(message);
            }
            message.Dispose();
        }

        public static MailMessage BuildMessage(string sender, string subject, string recipient, string messageBody, string template = null, string[] viewData = null, string Cc = null, string Bcc = null)
        {
            MailMessage message = new MailMessage(sender, recipient, subject, ComposeMessage(subject, messageBody, template, viewData));

            //Email carbon copy
            if (!string.IsNullOrEmpty(Cc))
            {
                string[] copy = Cc.ToLower().Split(',');
                foreach (var item in copy)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        message.CC.Add(item);
                    }
                }
            }

            //Email blind copy
            if (!string.IsNullOrEmpty(Bcc))
            {
                string[] blindCopy = Bcc.ToLower().Split(',');
                foreach (var item in blindCopy)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        message.Bcc.Add(item);
                    }
                }
            }
            return message;
        }

        public static string ComposeMessage(string subject, string message, string template = null, string[] viewData = null)
        {
            //use message as body by default
            string body = message;
            //use template if available
            if (!string.IsNullOrEmpty(template))
            {
                //var sr = new StreamReader(string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, template))
                using (var sr = new StreamReader(template))
                {
                    body = sr.ReadToEnd();
                }
            }
            //replace static content
            body = body.Replace("{{Subject}}", subject);
            body = body.Replace("{{Message}}", message);
            body = body.Replace("{{Date}}", DateTime.Now.ToShortDateString());
            body = body.Replace("{{Year}}", DateTime.Now.Year.ToString());

            //asign view data to the template
            if (viewData != null && viewData.Length > 0)
            {
                foreach (var item in viewData)
                {
                    string[] data = item.Split(new char[] { ':' }, 2);
                    if (!string.IsNullOrEmpty(data[0]))
                    {
                        body = body.Replace("{{" + data[0] + "}}", data[1]);
                    }
                }
            }
            return body;
        }
    }
}
