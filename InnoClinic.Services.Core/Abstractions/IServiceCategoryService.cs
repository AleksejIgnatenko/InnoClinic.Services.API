using InnoClinic.Services.Core.Models.ServiceCategoryModels;

namespace InnoClinic.Services.Application.Services
{
    public interface IServiceCategoryService
    {
        Task CreateServiceCategoryAsync(string categoryName, int timeSlotSize);
        Task DeleteServiceCategoryAsync(Guid id);
        Task<IEnumerable<ServiceCategoryEntity>> GetAllServiceCategoryAsync();
        Task UpdateServiceCategoryAsync(Guid id, string categoryName, int timeSlotSize);
    }
}