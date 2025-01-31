namespace InnoClinic.Services.Core.Models
{
    public class MedicalServiceModel
    {
        public Guid Id { get; set; }
        public ServiceCategoryModel ServiceCategory { get; set; } = new ServiceCategoryModel();
        public string ServiceName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public SpecializationModel Specialization { get; set; } = new SpecializationModel();
        public bool IsActive { get; set; }
    }
}