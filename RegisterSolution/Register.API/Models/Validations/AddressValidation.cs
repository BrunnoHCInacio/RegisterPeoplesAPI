using System;
using FluentValidation;

namespace Register.API.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(a => a.Street)
                .NotEmpty()
                .WithMessage("O endereco deve ser informado")
                .Length(2, 200)
                .WithMessage("O endereco deve conter entre {MinLength} e{MaxLength}");

            RuleFor(a => a.Number)
                .NotEmpty()
                .WithMessage("O número deve ser informado");

            RuleFor(a=>a.District)
                .NotEmpty()
                .WithMessage("O bairro deve ser informado")
                .Length(2,100)
                .WithMessage("O bairro deve conter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(a => a.City)
                .NotEmpty()
                .WithMessage("A cidade deve ser informado")
                .Length(2,100)
                .WithMessage("A cidade deve conter entre {MinLength} e {Maxlength} caracteres");

            RuleFor(a => a.State)
                .NotEmpty()
                .WithMessage("O estado deve ser informado")
                .Length(2, 50)
                .WithMessage("O estado deve conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(a => a.Country)
                .NotEmpty()
                .WithMessage("O país deve ser informado")
                .Length(2, 50)
                .WithMessage("O país deve conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(a => a.ZipCode).NotEmpty().WithMessage("O CEP deve ser informado").Length(8).WithMessage("O CEP deve conter 8 caracteres");
        }
    }
}
