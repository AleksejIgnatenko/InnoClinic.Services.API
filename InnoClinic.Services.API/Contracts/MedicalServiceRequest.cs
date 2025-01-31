namespace InnoClinic.Services.API.Contracts
{
    public record MedicalServiceRequest(
        Guid ServiceCategoryId, 
        string ServiceName, 
        decimal Price, 
        Guid SpecializationId, 
        bool IsActive
        );
}
