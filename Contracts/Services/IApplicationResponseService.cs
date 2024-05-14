using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Dtos;

namespace DotnetInterviewTask.Contracts
{
    public interface IApplicationResponseService
    {
        Task<ApplicationResponseDto> CreateAsync(CreateApplicationResponseRequestModel requestModel);

    }
}