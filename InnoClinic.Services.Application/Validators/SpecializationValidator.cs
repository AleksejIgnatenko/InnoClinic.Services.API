using FluentValidation;
using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.Application.Validators
{
    internal class SpecializationValidator : AbstractValidator<SpecializationEntity>
    {
        public SpecializationValidator()
        {
            RuleFor(x => x.SpecializationName)
                .NotEmpty().WithMessage("The specialization name cannot be empty.");
        }
    }
}
