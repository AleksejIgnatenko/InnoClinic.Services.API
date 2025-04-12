using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models.MedicalServiceModels;

namespace InnoClinic.Services.DataAccess.Repositories
{
    public interface IMedicalServiceRepository : IRepositoryBase<MedicalServiceEntity>
    {
        Task<IEnumerable<MedicalServiceEntity>> GetAllAsync();
        Task<IEnumerable<MedicalServiceEntity>> GetAllActiveMedicalServicesAsync();
        Task<MedicalServiceEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<MedicalServiceEntity>> GetBySpecializationIdAsync(Guid specializationId);
    }
}