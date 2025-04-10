using FluentValidation;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;

namespace InnoClinic.Services.Application.Validators
{
    internal class ServiceCategoryValidator : AbstractValidator<ServiceCategoryEntity>
    {
        public ServiceCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("The category name cannot be empty.");

            RuleFor(x => x.TimeSlotSize)
                    .GreaterThan(0).WithMessage("The timeslot size must be greater than 0.");
        }
    }
}
