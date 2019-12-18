using RegisterPeoples.Interfaces;
using RegisterPeoples.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Services
{
    public class BaseService
    {
        private readonly INotifier _notifier;

        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }
    }
}
