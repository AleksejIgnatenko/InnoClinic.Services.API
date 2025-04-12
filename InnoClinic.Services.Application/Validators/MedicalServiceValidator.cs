using FluentValidation;
using InnoClinic.Services.Core.Models.MedicalServiceModels;

namespace InnoClinic.Services.Application.Validators
{
    internal class MedicalServiceValidator : AbstractValidator<MedicalServiceEntity>
    {
        public MedicalServiceValidator()
        {
            RuleFor(x => x.ServiceName)
                .NotEmpty().WithMessage("The medical service name cannot be empty.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("The price must be greater than or equal to 0.");
        }
    }
}
