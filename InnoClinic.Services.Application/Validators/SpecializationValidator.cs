using FluentValidation;
using InnoClinic.Services.Core.Models;

namespace InnoClinic.Services.Application.Validators
{
    internal class SpecializationValidator : AbstractValidator<SpecializationModel>
    {
        public SpecializationValidator()
        {
            RuleFor(x => x.SpecializationName)
                .NotEmpty().WithMessage("The specialization name cannot be empty.");
        }
    }
}
