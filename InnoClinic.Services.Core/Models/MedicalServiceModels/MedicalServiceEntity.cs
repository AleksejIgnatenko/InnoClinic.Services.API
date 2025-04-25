using InnoClinic.Services.Core.Models.ServiceCategoryModels;
using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.Core.Models.MedicalServiceModels;

/// <summary>
/// Represents a medical service entity.
/// </summary>
public class MedicalServiceEntity : EntityBase
{
    /// <summary>
    /// Gets or sets the service category of the medical service.
    /// </summary>
    public ServiceCategoryEntity ServiceCategory { get; set; } = new ServiceCategoryEntity();

    /// <summary>
    /// Gets or sets the name of the medical service.
    /// </summary>
    public string ServiceName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price of the medical service.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the specialization associated with the medical service.
    /// </summary>
    public SpecializationEntity Specialization { get; set; } = new SpecializationEntity();

    /// <summary>
    /// Gets or sets a value indicating whether the medical service is active.
    /// </summary>
    public bool IsActive { get; set; }
}