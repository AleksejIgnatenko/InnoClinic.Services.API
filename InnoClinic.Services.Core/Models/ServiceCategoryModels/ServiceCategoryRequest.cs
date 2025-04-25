namespace InnoClinic.Services.Core.Models.ServiceCategoryModels;

/// <summary>
/// Represents a service category request.
/// </summary>
public record ServiceCategoryRequest(
    /// <summary>
    /// Gets the name of the category.
    /// </summary>
    string CategoryName,

    /// <summary>
    /// Gets the time slot size for the category.
    /// </summary>
    int TimeSlotSize
);