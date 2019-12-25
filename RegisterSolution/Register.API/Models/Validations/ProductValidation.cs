using System;
using FluentValidation;

namespace Register.API.Models.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("O nome do produto precisa ser fornecido")
                .Length(2,200)
                .WithMessage("O nome do produto deve conter entre {MinLength} e {MaxLength}");

            RuleFor(p => p.Value)
                .NotEmpty()
                .WithMessage("O valor deve ser informado");
        }
    }
}
