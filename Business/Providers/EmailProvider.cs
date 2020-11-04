using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Business.Providers
{
    public class EmailProvider: IEmailProvider
    {
        private readonly EmailConfig _emailConfig;
        private readonly IConfiguration _configuration;

        public EmailProvider(IOptions<EmailConfig> emailConfig, IConfiguration configuration)
        {
            _emailConfig = emailConfig.Value;
            _configuration = configuration;
            //bing emailconfig on appsettings to emailconfig model
        }

        public async Task SendQuickMail(string recipient, string subject, string message, string Cc = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(recipient))
                {
                    MailMessage messageBuilder = EmailHelper.BuildMessage(_emailConfig.Sender, subject, recipient, message, Cc: Cc);
                    await EmailHelper.SendAsync(_emailConfig, messageBuilder, true, _emailConfig.Smtp.UseSSL);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
