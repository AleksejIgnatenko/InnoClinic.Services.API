namespace InnoClinic.Services.Core.Models.MedicalServiceModels;

/// <summary>
/// Represents a medical service data transfer object (DTO).
/// </summary>
public record MedicalServiceDto(
    /// <summary>
    /// Gets the ID of the medical service.
    /// </summary>
    Guid Id,

    /// <summary>
    /// Gets the name of the medical service.
    /// </summary>
    string ServiceName,

    /// <summary>
    /// Gets the price of the medical service.
    /// </summary>
    decimal Price,

    /// <summary>
    /// Gets a value indicating whether the medical service is active.
    /// </summary>
    bool IsActive
);