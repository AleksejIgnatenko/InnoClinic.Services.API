using InnoClinic.Services.Core.Models;

namespace InnoClinic.Services.Application.Services
{
    public interface IMedicalServiceService
    {
        Task CreateMedicalServiceAsync(Guid serviceCategoryId, string serviceName, decimal price, Guid specializationId, bool isActive);
        Task DeleteMedicalServiceAsync(Guid id);
        Task<IEnumerable<MedicalServiceModel>> GetAllMedicalServiceAsync();
        Task UpdateMedicalServiceAsync(Guid id, Guid serviceCategoryId, string serviceName, decimal price, Guid specializationId, bool isActive);
    }
}