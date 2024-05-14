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
    public class ApplicationResponseController (IApplicationResponseService applicationResponseService): ControllerBase
    {
        private readonly IApplicationResponseService _applicationResponseService = applicationResponseService;

        [HttpPost]
        public async Task<IActionResult> Create(CreateApplicationResponseRequestModel request)
        {
            return Ok(await _applicationResponseService.CreateAsync(request));
        }
    }
}