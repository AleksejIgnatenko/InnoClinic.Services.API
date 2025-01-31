using InnoClinic.Services.Core.Models;

namespace InnoClinic.Services.Application.Services
{
    public interface IServiceCategoryService
    {
        Task CreateServiceCategoryAsync(string categoryName, int timeSlotSize);
        Task DeleteServiceCategoryAsync(Guid id);
        Task<IEnumerable<ServiceCategoryModel>> GetAllServiceCategoryAsync();
        Task UpdateServiceCategoryAsync(Guid id, string categoryName, int timeSlotSize);
    }
}