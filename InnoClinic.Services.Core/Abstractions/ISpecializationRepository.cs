using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models;

namespace InnoClinic.Services.DataAccess.Repositories
{
    public interface ISpecializationRepository : IRepositoryBase<SpecializationModel>
    {
        Task<IEnumerable<SpecializationModel>> GetAllAsync();
        Task<SpecializationModel> GetByIdAsync(Guid id);
    }
}