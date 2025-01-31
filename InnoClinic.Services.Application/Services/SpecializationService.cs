using AutoMapper;
using InnoClinic.Services.Core.Dto;
using InnoClinic.Services.Core.Exceptions;
using InnoClinic.Services.Core.Models;
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
            var specialization = new SpecializationModel
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

        public async Task<IEnumerable<SpecializationModel>> GetAllSpecializationAsync()
        {
            return await _specializationRepository.GetAllAsync();
        }

        public async Task UpdateSpecializationAsync(Guid id, string specializationName, bool isActive)
        {
            var specialization = new SpecializationModel
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
