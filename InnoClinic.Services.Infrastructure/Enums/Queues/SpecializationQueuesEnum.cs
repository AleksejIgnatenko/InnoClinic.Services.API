namespace InnoClinic.Services.Infrastructure.Enums.Queues;

/// <summary>
/// Represents different types of queues related to specializations.
/// </summary>
public enum SpecializationQueuesEnum
{
    /// <summary>
    /// Represents the queue for adding a specialization.
    /// </summary>
    AddSpecialization,

    /// <summary>
    /// Represents the queue for updating a specialization.
    /// </summary>
    UpdateSpecialization,

    /// <summary>
    /// Represents the queue for deleting a specialization.
    /// </summary>
    DeleteSpecialization
}