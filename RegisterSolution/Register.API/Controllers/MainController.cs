using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Register.API.Interfaces;
using Register.API.Notifications;

namespace Register.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier _notifier;
        public readonly IUser AppUser;

        public bool UserIsAutenticate { get; set; }
        public Guid UserId { get; set; }

        public MainController(INotifier notifier, IUser appUser)
        {
            _notifier = notifier;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UserIsAutenticate = true;
                UserId = appUser.GetUserId();
            }
        }

        private bool OperacaoValida()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyErrorModelState(modelState);

            return CustomResponse();
        }

        protected void NotifyErrorModelState(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null 
                                    ? error.ErrorMessage 
                                    : error.Exception.Message;
                Notify(errorMessage);
   
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }
    }
}
