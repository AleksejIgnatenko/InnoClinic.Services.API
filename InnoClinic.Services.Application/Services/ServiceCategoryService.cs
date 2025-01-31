using InnoClinic.Services.Core.Exceptions;
using InnoClinic.Services.Core.Models;
using InnoClinic.Services.DataAccess.Repositories;

namespace InnoClinic.Services.Application.Services
{
    public class ServiceCategoryService : IServiceCategoryService
    {
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IValidationService _validationService;

        public ServiceCategoryService(IServiceCategoryRepository serviceCategoryRepository, IValidationService validationService)
        {
            _serviceCategoryRepository = serviceCategoryRepository;
            _validationService = validationService;
        }

        public async Task CreateServiceCategoryAsync(string categoryName, int timeSlotSize)
        {
            var serviceCategory = new ServiceCategoryModel
            {
                Id = Guid.NewGuid(),
                CategoryName = categoryName,
                TimeSlotSize = timeSlotSize
            };

            var validationErrors = _validationService.Validation(serviceCategory);

            if (validationErrors.Count != 0)
            {
                throw new ValidationException(validationErrors);
            }

            await _serviceCategoryRepository.CreateAsync(serviceCategory);
        }

        public async Task<IEnumerable<ServiceCategoryModel>> GetAllServiceCategoryAsync()
        {
            return await _serviceCategoryRepository.GetAllAsync();
        }

        public async Task UpdateServiceCategoryAsync(Guid id, string categoryName, int timeSlotSize)
        {
            var serviceCategory = new ServiceCategoryModel
            {
                Id = id,
                CategoryName = categoryName,
                TimeSlotSize = timeSlotSize
            };

            var validationErrors = _validationService.Validation(serviceCategory);

            if (validationErrors.Count != 0)
            {
                throw new ValidationException(validationErrors);
            }

            await _serviceCategoryRepository.UpdateAsync(serviceCategory);
        }

        public async Task DeleteServiceCategoryAsync(Guid id)
        {
            var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(id);
            await _serviceCategoryRepository.DeleteAsync(serviceCategory);
        }
    }
}
