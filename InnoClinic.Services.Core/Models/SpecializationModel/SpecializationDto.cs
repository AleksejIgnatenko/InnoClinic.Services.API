namespace InnoClinic.Services.Core.Models.SpecializationModel;

/// <summary>
/// Represents a specialization data transfer object (DTO).
/// </summary>
public record SpecializationDto(
    /// <summary>
    /// Gets the ID of the specialization.
    /// </summary>
    Guid Id,

    /// <summary>
    /// Gets the name of the specialization.
    /// </summary>
    string SpecializationName,

    /// <summary>
    /// Gets a value indicating whether the specialization is active.
    /// </summary>
    bool IsActive
);