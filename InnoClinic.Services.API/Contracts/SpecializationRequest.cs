namespace InnoClinic.Services.API.Contracts
{
    public record SpecializationRequest(
        string SpecializationName,
        bool IsActive
        );
}
