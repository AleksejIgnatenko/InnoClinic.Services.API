namespace InnoClinic.Services.Core.Models.MedicalServiceModels
{
    public record MedicalServiceRequest(
        Guid ServiceCategoryId,
        string ServiceName,
        decimal Price,
        Guid SpecializationId,
        bool IsActive
        );
}
