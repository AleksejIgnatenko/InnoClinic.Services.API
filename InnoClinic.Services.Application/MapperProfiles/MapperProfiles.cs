using AutoMapper;
using InnoClinic.Services.Core.Models.MedicalServiceModels;
using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.Application.MapperProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<SpecializationEntity, SpecializationDto>();
            CreateMap<MedicalServiceEntity, MedicalServiceDto>();
        }
    }
}
