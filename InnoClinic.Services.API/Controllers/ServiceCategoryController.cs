using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.Services.API.Controllers;

/// <summary>
/// Provides RESTful API endpoints for managing service categories.
/// </summary>
[Authorize(Roles = "Receptionist")]
[ApiController]
[Route("api/[controller]")]
public class ServiceCategoryController : ControllerBase
{
    private readonly IServiceCategoryService _serviceCategoryService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceCategoryController"/> class.
    /// </summary>
    /// <param name="serviceCategoryService">The service category service.</param>
    public ServiceCategoryController(IServiceCategoryService serviceCategoryService)
    {
        _serviceCategoryService = serviceCategoryService;
    }

    /// <summary>
    /// Creates a new service category.
    /// </summary>
    /// <param name="serviceCategoryRequest">The service category request.</param>
    /// <returns>Returns 200 OK on success.</returns>
    [HttpPost]
    public async Task<ActionResult> CreateServiceCategoryAsync([FromBody] ServiceCategoryRequest serviceCategoryRequest)
    {
        await _serviceCategoryService.CreateServiceCategoryAsync(serviceCategoryRequest);
        return Ok();
    }

    /// <summary>
    /// Retrieves all service categories.
    /// </summary>
    /// <returns>Returns a list of all service categories.</returns>
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult> GetAllServiceCategoryAsync()
    {
        return Ok(await _serviceCategoryService.GetAllServiceCategoryAsync());
    }

    /// <summary>
    /// Updates an existing service category.
    /// </summary>
    /// <param name="id">The unique identifier of the service category.</param>
    /// <param name="serviceCategoryRequest">The service category request.</param>
    /// <returns>Returns 200 OK on success.</returns>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateServiceCategoryAsync(Guid id, [FromBody] ServiceCategoryRequest serviceCategoryRequest)
    {
        await _serviceCategoryService.UpdateServiceCategoryAsync(id, serviceCategoryRequest);
        return Ok();
    }

    /// <summary>
    /// Deletes a service category by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the service category.</param>
    /// <returns>Returns 200 OK on success.</returns>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteServiceCategoryAsync(Guid id)
    {
        await _serviceCategoryService.DeleteServiceCategoryAsync(id);
        return Ok();
    }
}