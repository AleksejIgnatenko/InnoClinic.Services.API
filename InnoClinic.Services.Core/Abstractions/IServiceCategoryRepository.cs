using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;

namespace InnoClinic.Services.DataAccess.Repositories
{
    public interface IServiceCategoryRepository : IRepositoryBase<ServiceCategoryEntity>
    {
        Task<IEnumerable<ServiceCategoryEntity>> GetAllAsync();
        Task<ServiceCategoryEntity> GetByIdAsync(Guid id);
    }
}