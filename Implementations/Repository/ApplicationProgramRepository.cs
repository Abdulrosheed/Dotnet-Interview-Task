using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Context;
using DotnetInterviewTask.Contracts;
using DotnetInterviewTask.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetInterviewTask.Implementations
{
    public class ApplicationProgramRepository(ApplicationContext context) : IApplicationProgramRepository
    {
        private readonly ApplicationContext _context = context;

        public async Task<ApplicationProgram> CreateAsync(ApplicationProgram applicationProgram)
        {
            await _context.ApplicationPrograms.AddAsync(applicationProgram);
            return applicationProgram;
        }

        public async Task<IReadOnlyList<ApplicationProgram>> GetAllAsync()
        {
            return await _context.ApplicationPrograms.ToListAsync();
        }

        public async Task<ApplicationProgram?> GetAsync(Guid id)
        {
            return await _context.ApplicationPrograms.FirstOrDefaultAsync(a => a.Id == id);
        }

        public ApplicationProgram Update(ApplicationProgram applicationProgram)
        {
            _context.ApplicationPrograms.Update(applicationProgram);
            return applicationProgram;
        }
    }
}