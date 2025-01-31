using InnoClinic.Services.API.Contracts;
using InnoClinic.Services.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.Services.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSpecializationAsync([FromBody] SpecializationRequest specializationRequest)
        {
            await _specializationService.CreateSpecializationAsync(specializationRequest.SpecializationName, specializationRequest.IsActive);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSpecializationAsync()
        {
            return Ok(await _specializationService.GetAllSpecializationAsync());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateSpecializationAsync(Guid id, [FromBody] SpecializationRequest specializationRequest)
        {
            await _specializationService.UpdateSpecializationAsync(id, specializationRequest.SpecializationName, specializationRequest.IsActive);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteSpecializationAsync(Guid id)
        {
            await _specializationService.DeleteSpecializationAsync(id);

            return Ok();
        }
    }
}
