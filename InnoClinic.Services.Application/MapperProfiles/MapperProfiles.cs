using AutoMapper;
using InnoClinic.Services.Core.Dto;
using InnoClinic.Services.Core.Models;

namespace InnoClinic.Services.Application.MapperProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<SpecializationModel, SpecializationDto>();
            CreateMap<MedicalServiceModel, MedicalServiceDto>();
        }
    }
}
