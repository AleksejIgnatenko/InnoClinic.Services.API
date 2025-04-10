namespace InnoClinic.Services.Core.Models.ServiceCategoryModels
{
    public record ServiceCategoryRequest(
        string CategoryName,
        int TimeSlotSize
        );
}
