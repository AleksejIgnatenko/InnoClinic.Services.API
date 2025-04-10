using InnoClinic.Services.Core.Models.ServiceCategoryModels;
using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.Core.Models.MedicalServiceModels
{
    public class MedicalServiceEntity
    {
        public Guid Id { get; set; }
        public ServiceCategoryEntity ServiceCategory { get; set; } = new ServiceCategoryEntity();
        public string ServiceName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public SpecializationEntity Specialization { get; set; } = new SpecializationEntity();
        public bool IsActive { get; set; }
    }
}