using InnoClinic.Services.Core.Models.MedicalServiceModels;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;
using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.Application.Services
{
    public interface IValidationService
    {
        Dictionary<string, string> Validation(SpecializationEntity specializationModel);
        Dictionary<string, string> Validation(ServiceCategoryEntity serviceCategoryModel);
        Dictionary<string, string> Validation(MedicalServiceEntity medicalServiceModel);
    }
}