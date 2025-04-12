using InnoClinic.Services.Application.Services;
using InnoClinic.Services.Core.Models.SpecializationModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.Services.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        [Authorize(Roles = "Receptionist")]
        [HttpPost]
        public async Task<ActionResult> CreateSpecializationAsync([FromBody] SpecializationRequest specializationRequest)
        {
            await _specializationService.CreateSpecializationAsync(specializationRequest.SpecializationName, specializationRequest.IsActive);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAllSpecializationsAsync()
        {
            return Ok(await _specializationService.GetAllSpecializationsAsync());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSpecializationByIdAsync(Guid id)
        {
            return Ok(await _specializationService.GetSpecializationByIdAsync(id));
        }

        [AllowAnonymous]
        [HttpGet("all-active-specializations")]
        public async Task<ActionResult> GetAllActiveSpecializationsAsync()
        {
            return Ok(await _specializationService.GetAllActiveSpecializationsAsync());
        }

        [Authorize(Roles = "Receptionist")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateSpecializationAsync(Guid id, [FromBody] SpecializationRequest specializationRequest)
        {
            await _specializationService.UpdateSpecializationAsync(id, specializationRequest.SpecializationName, specializationRequest.IsActive);

            return Ok();
        }

        [Authorize(Roles = "Receptionist")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteSpecializationAsync(Guid id)
        {
            await _specializationService.DeleteSpecializationAsync(id);

            return Ok();
        }
    }
}
