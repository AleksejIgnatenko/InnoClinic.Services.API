namespace InnoClinic.Services.Core.Models.SpecializationModel;

/// <summary>
/// Represents a specialization request.
/// </summary>
public record SpecializationRequest(
    /// <summary>
    /// Gets the name of the specialization.
    /// </summary>
    string SpecializationName,

    /// <summary>
    /// Gets a value indicating whether the specialization is active.
    /// </summary>
    bool IsActive
);  