using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.DataAccess.Repositories
{
    public interface ISpecializationRepository : IRepositoryBase<SpecializationEntity>
    {
        Task<IEnumerable<SpecializationEntity>> GetAllAsync();
        Task<IEnumerable<SpecializationEntity>> GetAllActiveSpecializationsAsync();
        Task<SpecializationEntity> GetByIdAsync(Guid id);
    }
}