namespace InnoClinic.Services.Core.Models.ServiceCategoryModels;

/// <summary>
/// Represents a service category entity.
/// </summary>
public class ServiceCategoryEntity : EntityBase
{
    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the time slot size for the category.
    /// </summary>
    public int TimeSlotSize { get; set; }
}