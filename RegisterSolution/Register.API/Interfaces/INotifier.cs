using Register.API.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        void Handle(Notification notification);
        List<Notification> GetNotifications();
    }
}