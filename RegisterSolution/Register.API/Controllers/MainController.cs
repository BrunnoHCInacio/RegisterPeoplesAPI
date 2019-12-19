using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Register.API.Interfaces;

namespace Register.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier _notifier;

        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        public bool OperacaoValida()
        {
            return _notifier.HasNotification();
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
                errors = _notifier.GetNotifications().SelectMany(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyErrorModelState(modelState);

            return CustomResponse();
        }

        protected void NotifyErrorModelState(ModelStateDictionary modelState)
        {
            //var error = modelState
        }
    }
}
