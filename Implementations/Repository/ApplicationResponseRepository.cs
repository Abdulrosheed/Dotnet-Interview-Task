using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Context;
using DotnetInterviewTask.Contracts;
using DotnetInterviewTask.Models;

namespace DotnetInterviewTask.Implementations
{
    public class ApplicationResponseRepository(ApplicationContext context) : IApplicationResponseRepository
    {
        private readonly ApplicationContext _context = context;

        public async Task<ApplicationResponse> CreateAsync(ApplicationResponse applicationResponse)
        {
            await _context.ApplicationResponses.AddAsync(applicationResponse);
            return applicationResponse;
        }
    }
}