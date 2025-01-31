using FluentValidation.Results;
using InnoClinic.Services.Application.Validators;
using InnoClinic.Services.Core.Models;

namespace InnoClinic.Services.Application.Services
{
    public class ValidationService : IValidationService
    {
        public Dictionary<string, string> Validation(SpecializationModel specializationModel)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            SpecializationValidator validations = new SpecializationValidator();
            ValidationResult validationResult = validations.Validate(specializationModel);
            if (!validationResult.IsValid)
            {
                foreach (var failure in validationResult.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
            }

            return errors;
        }

        public Dictionary<string, string> Validation(ServiceCategoryModel serviceCategoryModel)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            ServiceCategoryValidator validations = new ServiceCategoryValidator();
            ValidationResult validationResult = validations.Validate(serviceCategoryModel);
            if (!validationResult.IsValid)
            {
                foreach (var failure in validationResult.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
            }

            return errors;
        }

        public Dictionary<string, string> Validation(MedicalServiceModel medicalServiceModel)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            MedicalServiceValidator validations = new MedicalServiceValidator();
            ValidationResult validationResult = validations.Validate(medicalServiceModel);
            if (!validationResult.IsValid)
            {
                foreach (var failure in validationResult.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
            }

            return errors;
        }
    }
}
