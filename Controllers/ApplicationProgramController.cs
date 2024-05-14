using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Contracts;
using DotnetInterviewTask.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DotnetInterviewTask.Extensions.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationProgramController(IApplicationProgramService applicationProgramService) : ControllerBase
    {
        private readonly IApplicationProgramService _applicationProgramService = applicationProgramService;

        [HttpPost]
        public async Task<IActionResult> Create(CreateApplicationProgramRequestModel request)
        {
            return Ok(await _applicationProgramService.CreateAsync(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _applicationProgramService.GetAllAsync());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateApplicationProgramRequestModel request)
        {
            return Ok(await _applicationProgramService.Update(id, request));
        }
    }
}