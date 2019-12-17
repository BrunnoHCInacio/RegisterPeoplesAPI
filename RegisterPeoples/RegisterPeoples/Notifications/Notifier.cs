using RegisterPeoples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Notifications
{
    public class Notifier : INotifier
    {
        public List<Notification> Notifications { get; set; }
        public Task<IEnumerable<Notification>> GetNotifications()
        {
            throw new NotImplementedException();
        }

        public Task Handle(Notification notification)
        {
            Notifications.Add(notification);
        }

        public Task<bool> HasNotification()
        {
            return Notifications.Any();
        }
    }
}
