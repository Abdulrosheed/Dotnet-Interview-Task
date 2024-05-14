using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Dtos;

namespace DotnetInterviewTask.Contracts
{
    public interface IApplicationProgramService
    {
        Task<ApplicationProgramDto> CreateAsync(CreateApplicationProgramRequestModel requestModel);
        Task<IReadOnlyList<ApplicationProgramDto>> GetAllAsync();
        Task<ApplicationProgramDto?> GetAsync (Guid id);
        Task<ApplicationProgramDto>  Update(Guid id, UpdateApplicationProgramRequestModel requestModel);
    }
}