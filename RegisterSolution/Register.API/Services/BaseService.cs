using FluentValidation;
using FluentValidation.Results;
using Register.API.Interfaces;
using Register.API.Models;
using Register.API.Notifications;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Services
{
    public class BaseService
    {
        private readonly INotifier _notifier;

        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool RunValidation<TValid, TEntity>(TValid validation,
                                                      TEntity entidade) where TValid : AbstractValidator<TEntity> where TEntity : Entity
        {
            var validator = validation.Validate(entidade);
            if (validator.IsValid) return true;
            Notify(validator);
            return false;
        }

                
    }
}
