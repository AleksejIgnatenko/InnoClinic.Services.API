namespace InnoClinic.Services.API.Contracts
{
    public record ServiceCategoryRequest(
        string CategoryName, 
        int TimeSlotSize
        );
}
