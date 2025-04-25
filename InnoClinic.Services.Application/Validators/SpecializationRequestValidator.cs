using FluentValidation;
using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.Application.Validators;

/// <summary>
/// Validator for validating <see cref="SpecializationRequestValidator"/> objects.
/// </summary>
internal class SpecializationRequestValidator : AbstractValidator<SpecializationRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpecializationRequestValidator"/> class.
    /// Configures validation rules for the <see cref="SpecializationRequestValidator"/> object.
    /// </summary>

    public SpecializationRequestValidator()
    {
        RuleFor(x => x.SpecializationName)
            .NotEmpty().WithMessage("The specialization name cannot be empty.");
    }
}