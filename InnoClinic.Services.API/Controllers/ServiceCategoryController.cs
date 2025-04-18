﻿using InnoClinic.Services.Application.Services;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.Services.API.Controllers
{
    [Authorize(Roles = "Receptionist")]
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly IServiceCategoryService _serviceCategoryService;

        public ServiceCategoryController(IServiceCategoryService serviceCategoryService)
        {
            _serviceCategoryService = serviceCategoryService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateServiceCategoryAsync([FromBody] ServiceCategoryRequest serviceCategoryRequest)
        {
            await _serviceCategoryService.CreateServiceCategoryAsync(serviceCategoryRequest.CategoryName, serviceCategoryRequest.TimeSlotSize);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAllServiceCategoryAsync()
        {
            return Ok(await _serviceCategoryService.GetAllServiceCategoryAsync());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateServiceCategoryAsync(Guid id, [FromBody] ServiceCategoryRequest serviceCategoryRequest)
        {
            await _serviceCategoryService.UpdateServiceCategoryAsync(id, serviceCategoryRequest.CategoryName, serviceCategoryRequest.TimeSlotSize);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteServiceCategoryAsync(Guid id)
        {
            await _serviceCategoryService.DeleteServiceCategoryAsync(id);

            return Ok();
        }
    }
}
