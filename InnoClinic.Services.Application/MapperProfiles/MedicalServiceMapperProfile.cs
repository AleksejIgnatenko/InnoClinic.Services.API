using AutoMapper;
using InnoClinic.Services.Core.Models.MedicalServiceModels;

namespace InnoClinic.Services.Application.MapperProfiles;

/// <summary>
/// Mapper profiles for mapping between different MedicalService-related classes.
/// </summary>
public class MedicalServiceMapperProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MedicalServiceMapperProfile"/> class.
    /// Configures mapping between <see cref="MedicalServiceRequest"/> and <see cref="MedicalServiceEntity"/>.
    /// </summary>
    public MedicalServiceMapperProfile()
    {
        CreateMap<MedicalServiceRequest, MedicalServiceEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ServiceCategory, opt => opt.Ignore())
                .ForMember(dest => dest.Specialization, opt => opt.Ignore());

        CreateMap<MedicalServiceEntity, MedicalServiceDto>();
    }
}
