using InnoClinic.Services.Core.Models.ServiceCategoryModels;

namespace InnoClinic.Services.Core.Abstractions;

/// <summary>
/// Interface for managing service categories.
/// </summary>
public interface IServiceCategoryService
{
    /// <summary>
    /// Creates a new service category asynchronously.
    /// </summary>
    /// <param name="serviceCategoryRequest">The service category request containing the name and time slot size.</param>
    Task CreateServiceCategoryAsync(ServiceCategoryRequest serviceCategoryRequest);

    /// <summary>
    /// Deletes a service category asynchronously.
    /// </summary>
    /// <param name="id">The ID of the service category to delete.</param>
    Task DeleteServiceCategoryAsync(Guid id);

    /// <summary>
    /// Retrieves all service categories asynchronously.
    /// </summary>
    /// <returns>A collection of all service categories.</returns>
    Task<IEnumerable<ServiceCategoryEntity>> GetAllServiceCategoryAsync();

    /// <summary>
    /// Updates a service category asynchronously.
    /// </summary>
    /// <param name="id">The ID of the service category to update.</param>
    /// <param name="serviceCategoryRequest">The service category request containing the updated name and time slot size.</param>
    Task UpdateServiceCategoryAsync(Guid id, ServiceCategoryRequest serviceCategoryRequest);
}