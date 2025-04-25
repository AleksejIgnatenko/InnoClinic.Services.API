namespace InnoClinic.Services.Infrastructure.Enums.Queues;

/// <summary>
/// Represents different types of queues related to medical services.
/// </summary>
public enum MedicalServiceQueuesEnum
{
    /// <summary>
    /// Represents the queue for adding a medical service.
    /// </summary>
    AddMedicalService,

    /// <summary>
    /// Represents the queue for updating a medical service.
    /// </summary>
    UpdateMedicalService,

    /// <summary>
    /// Represents the queue for deleting a medical service.
    /// </summary>
    DeleteMedicalService
}