namespace InnoClinic.Services.Core.Models.SpecializationModel
{
    public class SpecializationEntity
    {
        public Guid Id { get; set; }
        public string SpecializationName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
