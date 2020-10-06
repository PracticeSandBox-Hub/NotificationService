using Data.Common;
using System;

namespace Data.Entities
{
    public class Alert: BaseObject
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsSent { get; set; }
    }
}
