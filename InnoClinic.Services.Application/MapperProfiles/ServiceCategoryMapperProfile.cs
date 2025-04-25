using AutoMapper;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;

namespace InnoClinic.Services.Application.MapperProfiles;

/// <summary>
/// Mapper profiles for mapping between different ServiceCategory-related classes.
/// </summary>
internal class ServiceCategoryMapperProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceCategoryMapperProfile"/> class.
    /// Configures mapping between <see cref="ServiceCategoryRequest"/> and <see cref="ServiceCategoryEntity"/>.
    /// </summary>
    public ServiceCategoryMapperProfile()
    {
        CreateMap<ServiceCategoryRequest, ServiceCategoryEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}