using InnoClinic.Services.API.Contracts;
using InnoClinic.Services.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.Services.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalServiceController : ControllerBase
    {
        private readonly IMedicalServiceService _medicalServiceService;

        public MedicalServiceController(IMedicalServiceService medicalServiceService)
        {
            _medicalServiceService = medicalServiceService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateMedicalServiceAsync([FromBody] MedicalServiceRequest medicalServiceRequest)
        {
            await _medicalServiceService.CreateMedicalServiceAsync(medicalServiceRequest.ServiceCategoryId, 
                medicalServiceRequest.ServiceName, medicalServiceRequest.Price, medicalServiceRequest.SpecializationId, 
                medicalServiceRequest.IsActive);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMedicalServiceAsync()
        {
            return Ok(await _medicalServiceService.GetAllMedicalServiceAsync());
        }

        [HttpGet("get-all-services-by-category")]
        public async Task<ActionResult> GetAllServicesByCategoryAsync()
        {
            var medicalServices = await _medicalServiceService.GetAllMedicalServiceAsync();

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

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateMedicalServiceAsync(Guid id, [FromBody] MedicalServiceRequest medicalServiceRequest)
        {
            await _medicalServiceService.UpdateMedicalServiceAsync(id, medicalServiceRequest.ServiceCategoryId, 
                medicalServiceRequest.ServiceName, medicalServiceRequest.Price, medicalServiceRequest.SpecializationId, 
                medicalServiceRequest.IsActive);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteMedicalServiceAsync(Guid id)
        {
            await _medicalServiceService.DeleteMedicalServiceAsync(id);

            return Ok();
        }
    }
}
