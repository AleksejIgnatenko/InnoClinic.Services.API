using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models.SpecializationModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.Services.API.Controllers;

/// <summary>
/// Provides RESTful API endpoints for managing specializations.
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SpecializationController : ControllerBase
{
    private readonly ISpecializationService _specializationService;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpecializationController"/> class.
    /// </summary>
    /// <param name="specializationService">The specialization service.</param>
    public SpecializationController(ISpecializationService specializationService)
    {
        _specializationService = specializationService;
    }

    /// <summary>
    /// Creates a new specialization.
    /// </summary>
    /// <param name="specializationRequest">The specialization request.</param>
    /// <returns>Returns 200 OK on success.</returns>
    [Authorize(Roles = "Receptionist")]
    [HttpPost]
    public async Task<ActionResult> CreateSpecializationAsync([FromBody] SpecializationRequest specializationRequest)
    {
        await _specializationService.CreateSpecializationAsync(specializationRequest);
        return Ok();
    }

    /// <summary>
    /// Retrieves all specializations.
    /// </summary>
    /// <returns>Returns a list of all specializations.</returns>
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult> GetAllSpecializationsAsync()
    {
        return Ok(await _specializationService.GetAllSpecializationsAsync());
    }

    /// <summary>
    /// Retrieves a specialization by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the specialization.</param>
    /// <returns>Returns the details of the specified specialization.</returns>
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetSpecializationByIdAsync(Guid id)
    {
        return Ok(await _specializationService.GetSpecializationByIdAsync(id));
    }

    /// <summary>
    /// Retrieves all active specializations.
    /// </summary>
    /// <returns>Returns a list of all active specializations.</returns>
    [AllowAnonymous]
    [HttpGet("all-active-specializations")]
    public async Task<ActionResult> GetAllActiveSpecializationsAsync()
    {
        return Ok(await _specializationService.GetAllActiveSpecializationsAsync());
    }

    /// <summary>
    /// Updates an existing specialization.
    /// </summary>
    /// <param name="id">The unique identifier of the specialization.</param>
    /// <param name="specializationRequest">The specialization request.</param>
    /// <returns>Returns 200 OK on success.</returns>
    [Authorize(Roles = "Receptionist")]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateSpecializationAsync(Guid id, [FromBody] SpecializationRequest specializationRequest)
    {
        await _specializationService.UpdateSpecializationAsync(id, specializationRequest);
        return Ok();
    }

    /// <summary>
    /// Deletes a specialization by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the specialization.</param>
    /// <returns>Returns 200 OK on success.</returns>
    [Authorize(Roles = "Receptionist")]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteSpecializationAsync(Guid id)
    {
        await _specializationService.DeleteSpecializationAsync(id);
        return Ok();
    }
}