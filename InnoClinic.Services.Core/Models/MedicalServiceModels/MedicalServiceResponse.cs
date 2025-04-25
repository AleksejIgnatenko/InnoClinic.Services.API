using InnoClinic.Services.Core.Models.ServiceCategoryModels;
using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.Core.Models.MedicalServiceModels;

/// <summary>
/// Represents a medical service response.
/// </summary>
public record MedicalServiceResponse(
    /// <summary>
    /// Gets the ID of the medical service.
    /// </summary>
    Guid Id,

    /// <summary>
    /// Gets the service category of the medical service.
    /// </summary>
    ServiceCategoryEntity ServiceCategory,

    /// <summary>
    /// Gets the name of the medical service.
    /// </summary>
    string ServiceName,

    /// <summary>
    /// Gets the price of the medical service.
    /// </summary>
    string Price,

    /// <summary>
    /// Gets the specialization associated with the medical service.
    /// </summary>
    SpecializationEntity Specialization,

    /// <summary>
    /// Gets a value indicating whether the medical service is active.
    /// </summary>
    bool IsActive
);