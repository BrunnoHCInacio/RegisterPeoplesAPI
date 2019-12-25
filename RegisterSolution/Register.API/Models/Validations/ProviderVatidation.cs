using System;
using FluentValidation;

namespace Register.API.Models.Validations
{
    public class ProviderVatidation : AbstractValidator<Provider>
    {
        public ProviderVatidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome deve ser fornecido")
                .Length(2,100).WithMessage("O nome deve conter entre {MaxLength} e {MinLength} caracteres");

            When(p=>p.TypeProvider == TypeProvider.PhisicalPerson, () =>
            {
                RuleFor(p => p.Document.Length)
                    .Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O documento precisa ter {ComparisonValue} e foi fornecido {ProperyValue}.");

                RuleFor(p => CpfValidacao.Validar(p.Document))
                    .Equal(true).WithMessage("O documento fornecido é inválido");
            });
            When(p => p.TypeProvider == TypeProvider.LegalPerson, () =>
            {
                RuleFor(p => p.Document.Length)
                    .Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O documento precisa ter {ComparisonValue} e foi fornecido {ProperyValue}.");

                RuleFor(p => CnpjValidacao.Validar(p.Document))
                    .Equal(true)
                    .WithMessage("O documento fornecido é inválido");

            });
            
        }
    }
}
