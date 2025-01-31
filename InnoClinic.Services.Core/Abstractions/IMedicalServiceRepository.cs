using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models;

namespace InnoClinic.Services.DataAccess.Repositories
{
    public interface IMedicalServiceRepository : IRepositoryBase<MedicalServiceModel>
    {
        Task<IEnumerable<MedicalServiceModel>> GetAllAsync();
        Task<MedicalServiceModel> GetByIdAsync(Guid id);
    }
}