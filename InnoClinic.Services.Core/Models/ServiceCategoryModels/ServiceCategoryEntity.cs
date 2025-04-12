namespace InnoClinic.Services.Core.Models.ServiceCategoryModels
{
    public class ServiceCategoryEntity
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int TimeSlotSize { get; set; }
    }
}
