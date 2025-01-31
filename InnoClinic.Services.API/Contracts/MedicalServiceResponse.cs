using InnoClinic.Services.Core.Models;

namespace InnoClinic.Services.API.Contracts
{
    public record MedicalServiceResponse(
         Guid Id,
         ServiceCategoryModel ServiceCategory,
         string ServiceName,
         string Price,
         SpecializationModel Specialization,
         bool IsActive
        );
}
