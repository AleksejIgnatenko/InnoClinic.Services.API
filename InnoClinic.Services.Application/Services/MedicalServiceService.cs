using System.Diagnostics;
using AutoMapper;
using InnoClinic.Services.Core.Dto;
using InnoClinic.Services.Core.Exceptions;
using InnoClinic.Services.Core.Models;
using InnoClinic.Services.DataAccess.Repositories;
using InnoClinic.Services.Infrastructure.RabbitMQ;

namespace InnoClinic.Services.Application.Services
{
    public class MedicalServiceService : IMedicalServiceService
    {
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly ISpecializationRepository _specificationRepository;
        private readonly IMedicalServiceRepository _medicalServiceRepository;
        private readonly IValidationService _validationService;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IMapper _mapper;

        public MedicalServiceService(IServiceCategoryRepository serviceCategoryRepository, IValidationService validationService, ISpecializationRepository specificationRepository, IMedicalServiceRepository medicalServiceRepository, IRabbitMQService rabbitMQService, IMapper mapper)
        {
            _serviceCategoryRepository = serviceCategoryRepository;
            _validationService = validationService;
            _specificationRepository = specificationRepository;
            _medicalServiceRepository = medicalServiceRepository;
            _rabbitMQService = rabbitMQService;
            _mapper = mapper;
        }

        public async Task CreateMedicalServiceAsync(Guid serviceCategoryId, string serviceName, decimal price, Guid specializationId, bool isActive)
        {
            var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(serviceCategoryId);
            var specialization = await _specificationRepository.GetByIdAsync(specializationId);

            var medicalService = new MedicalServiceModel
            {
                Id = Guid.NewGuid(),
                ServiceCategory = serviceCategory,
                ServiceName = serviceName,
                Price = price,
                Specialization = specialization,
                IsActive = isActive
            };

            var validationErrors = _validationService.Validation(medicalService);

            if (validationErrors.Count != 0)
            {
                throw new ValidationException(validationErrors);
            }

            await _medicalServiceRepository.CreateAsync(medicalService);

            var medicalServiceDto = _mapper.Map<MedicalServiceDto>(medicalService);
            await _rabbitMQService.PublishMessageAsync(medicalServiceDto, RabbitMQQueues.ADD_MEDICAL_SERVICE_QUEUE);
        }

        public async Task<IEnumerable<MedicalServiceModel>> GetAllMedicalServiceAsync()
        {
            return await _medicalServiceRepository.GetAllAsync();
        }

        public async Task UpdateMedicalServiceAsync(Guid id, Guid serviceCategoryId, string serviceName, decimal price, Guid specializationId, bool isActive)
        {
            var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(serviceCategoryId);
            var specialization = await _specificationRepository.GetByIdAsync(specializationId);

            var medicalService = new MedicalServiceModel
            {
                Id = id,
                ServiceCategory = serviceCategory,
                ServiceName = serviceName,
                Price = price,
                Specialization = specialization,
                IsActive = isActive
            };

            var validationErrors = _validationService.Validation(medicalService);

            if (validationErrors.Count != 0)
            {
                throw new ValidationException(validationErrors);
            }

            await _medicalServiceRepository.UpdateAsync(medicalService);

            var medicalServiceDto = _mapper.Map<MedicalServiceDto>(medicalService);
            await _rabbitMQService.PublishMessageAsync(medicalServiceDto, RabbitMQQueues.UPDATE_MEDICAL_SERVICE_QUEUE);
        }

        public async Task DeleteMedicalServiceAsync(Guid id)
        {
            var medicalService = await _medicalServiceRepository.GetByIdAsync(id);
            await _medicalServiceRepository.DeleteAsync(medicalService);

            var medicalServiceDto = _mapper.Map<MedicalServiceDto>(medicalService);
            await _rabbitMQService.PublishMessageAsync(medicalServiceDto, RabbitMQQueues.DELETE_MEDICAL_SERVICE_QUEUE);
        }
    }
}
