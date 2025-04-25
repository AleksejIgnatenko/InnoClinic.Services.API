using FluentValidation;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;

namespace InnoClinic.Services.Application.Validators;

/// <summary>
/// Validator for validating <see cref="ServiceCategoryRequest"/> objects.
/// </summary>
internal class ServiceCategoryRequestValidator : AbstractValidator<ServiceCategoryRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceCategoryRequest"/> class.
    /// Configures validation rules for the <see cref="ServiceCategoryRequest"/> object.
    /// </summary>
    public ServiceCategoryRequestValidator()
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("The category name cannot be empty.");

        RuleFor(x => x.TimeSlotSize)
                .GreaterThan(0).WithMessage("The timeslot size must be greater than 0.");
    }
}