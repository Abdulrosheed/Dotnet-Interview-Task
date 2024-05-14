using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetInterviewTask.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        { 

        }
        public DbSet<ApplicationProgram> ApplicationPrograms { get; set; }
        public DbSet<ApplicationResponse> ApplicationResponses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultContainer("Programs");

            builder.Entity<ApplicationProgram>()
            .ToContainer("Programs")
            .HasPartitionKey(a => a.Id)
            .HasNoDiscriminator();

            builder.Entity<ApplicationResponse>()
            .ToContainer("Responses")
            .HasPartitionKey(a => a.Id)
            .HasNoDiscriminator();
        }
    }
}