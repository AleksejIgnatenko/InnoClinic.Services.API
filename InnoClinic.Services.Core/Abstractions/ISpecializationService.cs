using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.Application.Services
{
    public interface ISpecializationService
    {
        Task CreateSpecializationAsync(string specializationName, bool isActive);
        Task<IEnumerable<SpecializationEntity>> GetAllSpecializationsAsync();
        Task<IEnumerable<SpecializationEntity>> GetAllActiveSpecializationsAsync();
        Task<SpecializationEntity> GetSpecializationByIdAsync(Guid id);
        Task UpdateSpecializationAsync(Guid id, string specializationName, bool isActive);
        Task DeleteSpecializationAsync(Guid id);
    }
}