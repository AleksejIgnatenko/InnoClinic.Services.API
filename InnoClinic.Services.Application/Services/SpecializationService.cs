using AutoMapper;
using InnoClinic.Services.Core.Exceptions;
using InnoClinic.Services.Core.Models.SpecializationModel;
using InnoClinic.Services.DataAccess.Repositories;
using InnoClinic.Services.Infrastructure.RabbitMQ;

namespace InnoClinic.Services.Application.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _specializationRepository;
        private readonly IValidationService _validationService;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IMapper _mapper;

        public SpecializationService(ISpecializationRepository specializationRepository, IValidationService validationService, IRabbitMQService rabbitMQService, IMapper mapper)
        {
            _specializationRepository = specializationRepository;
            _validationService = validationService;
            _rabbitMQService = rabbitMQService;
            _mapper = mapper;
        }

        public async Task CreateSpecializationAsync(string specializationName, bool isActive)
        {
            var specialization = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                SpecializationName = specializationName,
                IsActive = isActive,
            };

            var validationErrors = _validationService.Validation(specialization);

            if (validationErrors.Count != 0)
            {
                throw new ValidationException(validationErrors);
            }

            await _specializationRepository.CreateAsync(specialization);

            var specializationDto = _mapper.Map<SpecializationDto>(specialization);
            await _rabbitMQService.PublishMessageAsync(specialization, RabbitMQQueues.ADD_SPECIALIZATION_QUEUE);
        }

        public async Task<IEnumerable<SpecializationEntity>> GetAllSpecializationsAsync()
        {
            return await _specializationRepository.GetAllAsync();
        }

        public async Task<SpecializationEntity> GetSpecializationByIdAsync(Guid id)
        {
            return await _specializationRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SpecializationEntity>> GetAllActiveSpecializationsAsync()
        {
            return await _specializationRepository.GetAllActiveSpecializationsAsync();
        }

        public async Task UpdateSpecializationAsync(Guid id, string specializationName, bool isActive)
        {
            var specialization = new SpecializationEntity
            {
                Id = id,
                SpecializationName = specializationName,
                IsActive = isActive,
            };

            var validationErrors = _validationService.Validation(specialization);

            if (validationErrors.Count != 0)
            {
                throw new ValidationException(validationErrors);
            }

            await _specializationRepository.UpdateAsync(specialization);

            var specializationDto = _mapper.Map<SpecializationDto>(specialization);
            await _rabbitMQService.PublishMessageAsync(specialization, RabbitMQQueues.UPDATE_SPECIALIZATION_QUEUE);
        }

        public async Task DeleteSpecializationAsync(Guid id)
        {
            var specialization = await _specializationRepository.GetByIdAsync(id);
            await _specializationRepository.DeleteAsync(specialization);

            await _rabbitMQService.PublishMessageAsync(specialization, RabbitMQQueues.DELETE_SPECIALIZATION_QUEUE);
        }
    }
}
