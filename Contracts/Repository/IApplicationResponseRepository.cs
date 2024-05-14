using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Models;

namespace DotnetInterviewTask.Contracts
{
    public interface IApplicationResponseRepository
    {
        Task<ApplicationResponse> CreateAsync(ApplicationResponse applicationResponse);

    }
}