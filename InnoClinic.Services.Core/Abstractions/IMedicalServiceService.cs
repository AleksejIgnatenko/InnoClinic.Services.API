using InnoClinic.Services.Core.Models.MedicalServiceModels;

namespace InnoClinic.Services.Application.Services
{
    public interface IMedicalServiceService
    {
        Task CreateMedicalServiceAsync(Guid serviceCategoryId, string serviceName, decimal price, Guid specializationId, bool isActive);
        Task DeleteMedicalServiceAsync(Guid id);
        Task<IEnumerable<MedicalServiceEntity>> GetAllMedicalServiceAsync();
        Task<MedicalServiceEntity> GetMedicalServiceByIdAsync(Guid id);
        Task<IEnumerable<MedicalServiceEntity>> GetAllActiveMedicalServicesAsync();
        Task UpdateMedicalServiceAsync(Guid id, Guid serviceCategoryId, string serviceName, decimal price, Guid specializationId, bool isActive);
        Task<IEnumerable<MedicalServiceEntity>> GetServicesBySpecializationIdAsync(Guid specializationId);
    }
}