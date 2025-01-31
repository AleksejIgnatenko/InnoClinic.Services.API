
using InnoClinic.Services.Core.Models;

namespace InnoClinic.Services.Application.Services
{
    public interface ISpecializationService
    {
        Task CreateSpecializationAsync(string specializationName, bool isActive);
        Task<IEnumerable<SpecializationModel>> GetAllSpecializationAsync();
        Task UpdateSpecializationAsync(Guid id, string specializationName, bool isActive);
        Task DeleteSpecializationAsync(Guid id);
    }
}