using FluentValidation;
using InnoClinic.Services.Core.Models.MedicalServiceModels;

namespace InnoClinic.Services.Application.Validators;

/// <summary>
/// Validator for validating <see cref="MedicalServiceRequest"/> objects.
/// </summary>
internal class MedicalServiceRequestValidator : AbstractValidator<MedicalServiceRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MedicalServiceRequest"/> class.
    /// Configures validation rules for the <see cref="MedicalServiceRequest"/> object.
    /// </summary>
    public MedicalServiceRequestValidator()
    {
        RuleFor(x => x.ServiceName)
            .NotEmpty().WithMessage("The medical service name cannot be empty.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("The price must be greater than or equal to 0.");
    }
}
