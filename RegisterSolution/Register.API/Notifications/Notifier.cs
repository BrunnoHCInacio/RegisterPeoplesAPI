using Register.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Notifications
{
    public class Notifier : INotifier
    {
        List<Notification> notifications;
        public Notifier()
        {
            notifications = new List<Notification>();
        }
        public List<Notification> GetNotifications()
        {
            return notifications;
        }

        public void Handle(Notification notification)
        {
            notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return notifications.Any();
        }
    }
}
