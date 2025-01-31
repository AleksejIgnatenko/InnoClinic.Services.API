using InnoClinic.Services.Core.Models;

namespace InnoClinic.Services.Application.Services
{
    public interface IValidationService
    {
        Dictionary<string, string> Validation(SpecializationModel specializationModel);
        Dictionary<string, string> Validation(ServiceCategoryModel serviceCategoryModel);
        Dictionary<string, string> Validation(MedicalServiceModel medicalServiceModel);
    }
}