using RegisterPeoples.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Interfaces
{
    interface INotifier
    {
        Task HasNotification();
        Task Handle(Notification notification);
        Task<IEnumerable<Notification>> GetNotifications();
    }
}
