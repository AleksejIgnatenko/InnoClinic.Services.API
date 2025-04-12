using InnoClinic.Services.Core.Models.ServiceCategoryModels;
using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.Core.Models.MedicalServiceModels
{
    public record MedicalServiceResponse(
         Guid Id,
         ServiceCategoryEntity ServiceCategory,
         string ServiceName,
         string Price,
         SpecializationEntity Specialization,
         bool IsActive
        );
}
