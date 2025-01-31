using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models;

namespace InnoClinic.Services.DataAccess.Repositories
{
    public interface IServiceCategoryRepository : IRepositoryBase<ServiceCategoryModel>
    {
        Task<IEnumerable<ServiceCategoryModel>> GetAllAsync();
        Task<ServiceCategoryModel> GetByIdAsync(Guid id);
    }
}