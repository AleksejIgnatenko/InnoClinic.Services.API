using AutoMapper;
using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models.SpecializationModel;
using InnoClinic.Services.Infrastructure.Enums.Queues;

namespace InnoClinic.Services.Application.Services;

/// <summary>
/// Service for managing specialization entities including creation, retrieval, updating, and deletion operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="SpecializationService"/> class.
/// </remarks>
/// <param name="specializationRepository">The specialization repository for data access.</param>
/// <param name="rabbitMQService">The RabbitMQ service for message publishing.</param>
/// <param name="mapper">The mapper for object mapping.</param>
public class SpecializationService(ISpecializationRepository specializationRepository, IRabbitMQService rabbitMQService, IMapper mapper) : ISpecializationService
{
    private readonly ISpecializationRepository _specializationRepository = specializationRepository;
    private readonly IRabbitMQService _rabbitMQService = rabbitMQService;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Creates a new specialization based on the provided specialization request.
    /// </summary>
    public async Task CreateSpecializationAsync(SpecializationRequest specializationRequest)
    {
        var specialization = _mapper.Map<SpecializationEntity>(specializationRequest);

        await _specializationRepository.CreateAsync(specialization);

        var specializationDto = _mapper.Map<SpecializationDto>(specialization);
        await _rabbitMQService.PublishMessageAsync(specializationDto, SpecializationQueuesEnum.AddSpecialization.ToString());
    }

    /// <summary>
    /// Retrieves all specialization.
    /// </summary>
    public async Task<IEnumerable<SpecializationEntity>> GetAllSpecializationsAsync()
    {
        return await _specializationRepository.GetAllAsync();
    }

    /// <summary>
    /// Retrieves all active specializations.
    /// </summary>
    public async Task<IEnumerable<SpecializationEntity>> GetAllActiveSpecializationsAsync()
    {
        return await _specializationRepository.GetAllActiveSpecializationsAsync();
    }

    /// <summary>
    /// Retrieves an specialization by its unique identifier.
    /// </summary>
    public async Task<SpecializationEntity> GetSpecializationByIdAsync(Guid id)
    {
        return await _specializationRepository.GetByIdAsync(id);
    }

    /// <summary>
    /// Updates an existing specialization based on the provided Id and specialization request.
    /// </summary>
    public async Task UpdateSpecializationAsync(Guid id, SpecializationRequest specializationRequest)
    {
        var specialization = await _specializationRepository.GetByIdAsync(id);

        _mapper.Map(specializationRequest, specialization);

        await _specializationRepository.UpdateAsync(specialization);

        var specializationDto = _mapper.Map<SpecializationDto>(specialization);
        await _rabbitMQService.PublishMessageAsync(specializationDto, SpecializationQueuesEnum.UpdateSpecialization.ToString());
    }

    /// <summary>
    /// Deletes an specialization based on the provided Id.
    /// </summary>
    public async Task DeleteSpecializationAsync(Guid id)
    {
        var specialization = await _specializationRepository.GetByIdAsync(id);
        await _specializationRepository.DeleteAsync(specialization);

        await _rabbitMQService.PublishMessageAsync(specialization, SpecializationQueuesEnum.DeleteSpecialization.ToString());
    }
}