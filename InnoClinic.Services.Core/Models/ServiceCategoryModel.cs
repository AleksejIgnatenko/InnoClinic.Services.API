namespace InnoClinic.Services.Core.Models
{
    public class ServiceCategoryModel
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int TimeSlotSize { get; set; }
    }
}
