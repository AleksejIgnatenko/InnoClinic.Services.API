using AutoMapper;
using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.Application.MapperProfiles;

/// <summary>
/// Mapper profiles for mapping between different specialization-related classes.
/// </summary>
public class SpecializationMapperProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpecializationMapperProfile"/> class.
    /// Configures mapping between <see cref="SpecializationRequest"/> and <see cref="SpecializationEntity"/>.
    /// </summary>
    public SpecializationMapperProfile()
    {
        CreateMap<SpecializationRequest, SpecializationEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<SpecializationEntity, SpecializationDto>();
    }
}