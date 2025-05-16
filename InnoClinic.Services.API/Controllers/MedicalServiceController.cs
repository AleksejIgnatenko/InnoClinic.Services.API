using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models.MedicalServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.Services.API.Controllers;

/// <summary>
/// Provides RESTful API endpoints for managing medical services.
/// </summary>
[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class MedicalServiceController : ControllerBase
{
    private readonly IMedicalServiceService _medicalServiceService;

    /// <summary>
    /// Initializes a new instance of the <see cref="MedicalServiceController"/> class.
    /// </summary>
    /// <param name="medicalServiceService">The medical service service.</param>
    public MedicalServiceController(IMedicalServiceService medicalServiceService)
    {
        _medicalServiceService = medicalServiceService;
    }

    /// <summary>
    /// Creates a new medical service.
    /// </summary>
    /// <param name="medicalServiceRequest">The medical service request.</param>
    /// <returns>Returns 200 OK on success.</returns>
    [Authorize(Roles = "Receptionist")]
    [HttpPost]
    public async Task<ActionResult> CreateMedicalServiceAsync([FromBody] MedicalServiceRequest medicalServiceRequest)
    {
        await _medicalServiceService.CreateMedicalServiceAsync(medicalServiceRequest);
        return Ok();
    }

    /// <summary>
    /// Gets all medical services.
    /// </summary>
    /// <returns>Returns a list of all medical services.</returns>
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult> GetAllMedicalServiceAsync()
    {
        return Ok(await _medicalServiceService.GetAllMedicalServiceAsync());
    }

    /// <summary>
    /// Gets a medical service by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the medical service.</param>
    /// <returns>Returns the medical service details.</returns>
    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetAllMedicalServiceAsync(Guid id)
    {
        return Ok(await _medicalServiceService.GetMedicalServiceByIdAsync(id));
    }

    /// <summary>
    /// Gets services by specialization ID.
    /// </summary>
    /// <param name="specializationId">The unique identifier of the specialization.</param>
    /// <returns>Returns a list of services for the specified specialization.</returns>
    [AllowAnonymous]
    [HttpGet("services-by-specialization-id/{specializationId:guid}")]
    public async Task<ActionResult> GetServicesBySpecializationIdAsync(Guid specializationId)
    {
        return Ok(await _medicalServiceService.GetServicesBySpecializationIdAsync(specializationId));
    }

    /// <summary>
    /// Gets all services grouped by category.
    /// </summary>
    /// <returns>Returns grouped services by category.</returns>
    [AllowAnonymous]
    [HttpGet("all-services-by-category")]
    public async Task<ActionResult> GetAllServicesByCategoryAsync()
    {
        var medicalServices = await _medicalServiceService.GetAllActiveMedicalServicesAsync();
        var response = medicalServices.Select(m => new MedicalServiceResponse(m.Id, m.ServiceCategory, m.ServiceName,
            m.Price.ToString(), m.Specialization, m.IsActive));

        var groupedServices = response
            .GroupBy(service => service.ServiceCategory.CategoryName)
            .Select(group => new
            {
                CategoryName = group.Key,
                Services = group.ToList(),
            });

        return Ok(groupedServices);
    }

    /// <summary>
    /// Gets all active medical services.
    /// </summary>
    /// <returns>Returns a list of all active medical services.</returns>
    [AllowAnonymous]
    [HttpGet("all-active-medical-services")]
    public async Task<ActionResult> GetAllActiveMedicalServicesAsync()
    {
        return Ok(await _medicalServiceService.GetAllActiveMedicalServicesAsync());
    }

    /// <summary>
    /// Updates an existing medical service.
    /// </summary>
    /// <param name="id">The unique identifier of the medical service.</param>
    /// <param name="medicalServiceRequest">The medical service request.</param>
    /// <returns>Returns 200 OK on success.</returns>
    [Authorize(Roles = "Receptionist")]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateMedicalServiceAsync(Guid id, [FromBody] MedicalServiceRequest medicalServiceRequest)
    {
        await _medicalServiceService.UpdateMedicalServiceAsync(id, medicalServiceRequest);
        return Ok();
    }

    /// <summary>
    /// Deletes a medical service by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the medical service.</param>
    /// <returns>Returns 200 OK on success.</returns>
    [Authorize(Roles = "Receptionist")]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteMedicalServiceAsync(Guid id)
    {
        await _medicalServiceService.DeleteMedicalServiceAsync(id);
        return Ok();
    }
}