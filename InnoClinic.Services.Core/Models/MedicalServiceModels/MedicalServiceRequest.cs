namespace InnoClinic.Services.Core.Models.MedicalServiceModels;

/// <summary>
/// Represents a medical service request.
/// </summary>
public record MedicalServiceRequest(
    /// <summary>
    /// Gets the ID of the service category for the medical service.
    /// </summary>
    Guid ServiceCategoryId,

    /// <summary>
    /// Gets the name of the medical service.
    /// </summary>
    string ServiceName,

    /// <summary>
    /// Gets the price of the medical service.
    /// </summary>
    decimal Price,

    /// <summary>
    /// Gets the ID of the specialization for the medical service.
    /// </summary>
    Guid SpecializationId,

    /// <summary>
    /// Gets a value indicating whether the medical service is active.
    /// </summary>
    bool IsActive
);