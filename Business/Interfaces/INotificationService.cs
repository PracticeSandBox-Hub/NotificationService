using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface INotificationService
    {
        //GetNotificationByIdentity //CreateNotification //DeleteNotification(id) // DeleteAllNotification(identity) //
        Task<IEnumerable<Notification>> GetNotificationByIdentity(string identity);

        Task<bool> CreateNotification(Notification model);

        Task<bool> DeleteNotification(int id);

        Task<bool> DeleteNotifications(string identity);
    }
}
