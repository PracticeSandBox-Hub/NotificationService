using System.Threading.Tasks;

namespace Business.Providers
{
    public interface IEmailProvider
    {
        Task SendQuickMail(string recipient, string subject, string message, string Cc = null);
    }
}
