using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Context;
using DotnetInterviewTask.Contracts;

namespace DotnetInterviewTask.Implementations
{
    public class UnitOfWork(ApplicationContext context) : IUnitOfWork
    {
        private readonly ApplicationContext _context = context;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}