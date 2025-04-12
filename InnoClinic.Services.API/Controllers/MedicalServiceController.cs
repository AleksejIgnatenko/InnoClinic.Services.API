using InnoClinic.Services.Application.Services;
using InnoClinic.Services.Core.Models.MedicalServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.Services.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalServiceController : ControllerBase
    {
        private readonly IMedicalServiceService _medicalServiceService;

        public MedicalServiceController(IMedicalServiceService medicalServiceService)
        {
            _medicalServiceService = medicalServiceService;
        }

        [Authorize(Roles = "Receptionist")]
        [HttpPost]
        public async Task<ActionResult> CreateMedicalServiceAsync([FromBody] MedicalServiceRequest medicalServiceRequest)
        {
            await _medicalServiceService.CreateMedicalServiceAsync(medicalServiceRequest.ServiceCategoryId, 
                medicalServiceRequest.ServiceName, medicalServiceRequest.Price, medicalServiceRequest.SpecializationId, 
                medicalServiceRequest.IsActive);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAllMedicalServiceAsync()
        {
            return Ok(await _medicalServiceService.GetAllMedicalServiceAsync());
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetAllMedicalServiceAsync(Guid id)
        {
            return Ok(await _medicalServiceService.GetMedicalServiceByIdAsync(id));
        }

        [AllowAnonymous]
        [HttpGet("services-by-specialization-id/{specializationId:guid}")]
        public async Task<ActionResult> GetServicesBySpecializationIdAsync(Guid specializationId)
        {
            return Ok(await _medicalServiceService.GetServicesBySpecializationIdAsync(specializationId));
        }

        [AllowAnonymous]
        [HttpGet("all-services-by-category")]
        public async Task<ActionResult> GetAllServicesByCategoryAsync()
        {
            var medicalServices = await _medicalServiceService.GetAllActiveMedicalServicesAsync();

            var response = medicalServices.Select(m => new MedicalServiceResponse(m.Id, m.ServiceCategory, m.ServiceName,
                m.Price.ToString(), m.Specialization, m.IsActive));

            var groupedServices = response
                .GroupBy(service => service.ServiceCategory.CategoryName)
                .Select(group => new
                {
                    CategoryName = group.Key,
                    Services = group.ToList(),
                });

            return Ok(groupedServices);
        }

        [AllowAnonymous]
        [HttpGet("all-active-medical-services")]
        public async Task<ActionResult> GetAllActiveMedicalServicesAsync()
        {
            return Ok(await _medicalServiceService.GetAllActiveMedicalServicesAsync());
        }

        [Authorize(Roles = "Receptionist")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateMedicalServiceAsync(Guid id, [FromBody] MedicalServiceRequest medicalServiceRequest)
        {
            await _medicalServiceService.UpdateMedicalServiceAsync(id, medicalServiceRequest.ServiceCategoryId, 
                medicalServiceRequest.ServiceName, medicalServiceRequest.Price, medicalServiceRequest.SpecializationId, 
                medicalServiceRequest.IsActive);

            return Ok();
        }

        [Authorize(Roles = "Receptionist")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteMedicalServiceAsync(Guid id)
        {
            await _medicalServiceService.DeleteMedicalServiceAsync(id);

            return Ok();
        }
    }
}
