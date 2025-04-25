using AutoMapper;
using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;

namespace InnoClinic.Services.Application.Services;

/// <summary>
/// Service for managing service category entities including creation, retrieval, updating, and deletion operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ServiceCategoryService"/> class.
/// </remarks>
/// <param name="serviceCategoryRepository">The service category repository for data access.</param>
/// <param name="mapper">The mapper for object mapping.</param>
public class ServiceCategoryService(IServiceCategoryRepository serviceCategoryRepository, IMapper mapper) : IServiceCategoryService
{
    private readonly IServiceCategoryRepository _serviceCategoryRepository = serviceCategoryRepository;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Creates a new service category based on the provided service category request.
    /// </summary>
    public async Task CreateServiceCategoryAsync(ServiceCategoryRequest serviceCategoryRequest)
    {
        var serviceCategory = _mapper.Map<ServiceCategoryEntity>(serviceCategoryRequest);

        await _serviceCategoryRepository.CreateAsync(serviceCategory);
    }

    /// <summary>
    /// Retrieves all service category.
    /// </summary>
    public async Task<IEnumerable<ServiceCategoryEntity>> GetAllServiceCategoryAsync()
    {
        return await _serviceCategoryRepository.GetAllAsync();
    }

    /// <summary>
    /// Updates an existing service category based on the provided Id and service category request.
    /// </summary>
    public async Task UpdateServiceCategoryAsync(Guid id, ServiceCategoryRequest serviceCategoryRequest)
    {
        var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(id);

        _mapper.Map(serviceCategoryRequest, serviceCategory);

        await _serviceCategoryRepository.UpdateAsync(serviceCategory);
    }

    /// <summary>
    /// Deletes an service category based on the provided Id.
    /// </summary>
    public async Task DeleteServiceCategoryAsync(Guid id)
    {
        var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(id);
        await _serviceCategoryRepository.DeleteAsync(serviceCategory);
    }
}
