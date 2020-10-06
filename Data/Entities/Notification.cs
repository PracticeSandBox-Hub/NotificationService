using Data.Common;

namespace Data.Entities
{
    public class Notification: BaseObject
    {
        public string UserId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

}
