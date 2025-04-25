using AutoMapper;
using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models.MedicalServiceModels;
using InnoClinic.Services.Infrastructure.Enums.Queues;

namespace InnoClinic.Services.Application.Services;

/// <summary>
/// Service for managing medical service entities including creation, retrieval, updating, and deletion operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="MedicalServiceService"/> class.
/// </remarks>
/// <param name="serviceCategoryRepository">The service category repository for data access.</param>
/// <param name="specializatRepository">The specialization repository for data access.</param>
/// <param name="medicalServiceRepository">The medical service repository for data access.</param>
/// <param name="rabbitMQService">The RabbitMQ service for message publishing.</param>
/// <param name="mapper">The mapper for object mapping.</param>
public class MedicalServiceService(IServiceCategoryRepository serviceCategoryRepository, ISpecializationRepository specializatRepository, IMedicalServiceRepository medicalServiceRepository, IRabbitMQService rabbitMQService, IMapper mapper) : IMedicalServiceService
{
    private readonly IServiceCategoryRepository _serviceCategoryRepository = serviceCategoryRepository;
    private readonly ISpecializationRepository _specializatRepository = specializatRepository;
    private readonly IMedicalServiceRepository _medicalServiceRepository = medicalServiceRepository;
    private readonly IRabbitMQService _rabbitMQService = rabbitMQService;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Creates a new medical service based on the provided medical service request.
    /// </summary>
    public async Task CreateMedicalServiceAsync(MedicalServiceRequest medicalServiceRequest)
    {
        var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(medicalServiceRequest.ServiceCategoryId);
        var specialization = await _specializatRepository.GetByIdAsync(medicalServiceRequest.SpecializationId);

        var medicalService = _mapper.Map<MedicalServiceEntity>(medicalServiceRequest);
        medicalService.ServiceCategory = serviceCategory;
        medicalService.Specialization = specialization;

        await _medicalServiceRepository.CreateAsync(medicalService);

        var medicalServiceDto = _mapper.Map<MedicalServiceDto>(medicalService);
        await _rabbitMQService.PublishMessageAsync(medicalServiceDto, MedicalServiceQueuesEnum.AddMedicalService.ToString());
    }

    /// <summary>
    /// Retrieves all medical service.
    /// </summary>
    public async Task<IEnumerable<MedicalServiceEntity>> GetAllMedicalServiceAsync()
    {
        return await _medicalServiceRepository.GetAllAsync();
    }

    /// <summary>
    /// Retrieves all active medical service.
    /// </summary>
    public async Task<IEnumerable<MedicalServiceEntity>> GetAllActiveMedicalServicesAsync()
    {
        return await _medicalServiceRepository.GetAllActiveMedicalServicesAsync();
    }

    /// <summary>
    /// Retrieves an medical service by its unique identifier.
    /// </summary>
    public async Task<MedicalServiceEntity> GetMedicalServiceByIdAsync(Guid id)
    {
        return await _medicalServiceRepository.GetByIdAsync(id);
    }

    /// <summary>
    /// Retrieves all medical services associated with a specific specialization Id asynchronously.
    /// </summary>
    /// <param name="specializationId">The ID of the specialization to filter the medical services by.</param>
    /// <returns>A collection of medical services associated with the specified specialization ID.</returns>
    public async Task<IEnumerable<MedicalServiceEntity>> GetServicesBySpecializationIdAsync(Guid specializationId)
    {
        return await _medicalServiceRepository.GetBySpecializationIdAsync(specializationId);
    }

    /// <summary>
    /// Updates an existing medical service based on the provided Id and medical service request.
    /// </summary>
    public async Task UpdateMedicalServiceAsync(Guid id, MedicalServiceRequest medicalServiceRequest)
    {
        var medicalService = await _medicalServiceRepository.GetByIdAsync(id);
        var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(medicalServiceRequest.ServiceCategoryId);
        var specialization = await _specializatRepository.GetByIdAsync(medicalServiceRequest.SpecializationId);

        _mapper.Map(medicalServiceRequest, medicalService);
        medicalService.ServiceCategory = serviceCategory;
        medicalService.Specialization = specialization;

        await _medicalServiceRepository.UpdateAsync(medicalService);

        var medicalServiceDto = _mapper.Map<MedicalServiceDto>(medicalService);
        await _rabbitMQService.PublishMessageAsync(medicalServiceDto, MedicalServiceQueuesEnum.UpdateMedicalService.ToString());
    }

    /// <summary>
    /// Deletes an medical service based on the provided Id.
    /// </summary>
    public async Task DeleteMedicalServiceAsync(Guid id)
    {
        var medicalService = await _medicalServiceRepository.GetByIdAsync(id);
        await _medicalServiceRepository.DeleteAsync(medicalService);

        var medicalServiceDto = _mapper.Map<MedicalServiceDto>(medicalService);
        await _rabbitMQService.PublishMessageAsync(medicalServiceDto, MedicalServiceQueuesEnum.DeleteMedicalService.ToString());
    }
}