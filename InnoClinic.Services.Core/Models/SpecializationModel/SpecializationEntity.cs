namespace InnoClinic.Services.Core.Models.SpecializationModel;

/// <summary>
/// Represents a specialization entity.
/// </summary>
public class SpecializationEntity : EntityBase
{
    /// <summary>
    /// Gets or sets the name of the specialization.
    /// </summary>
    public string SpecializationName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the specialization is active.
    /// </summary>
    public bool IsActive { get; set; }
}