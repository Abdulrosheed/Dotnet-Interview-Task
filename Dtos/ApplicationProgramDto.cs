using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.ValueObjects;

namespace DotnetInterviewTask.Dtos
{
    public record ApplicationProgramDto
    {
        public Guid Id {get; set;}
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public IReadOnlyList<Question> Questions {get;set;} 

    }
    public record CreateApplicationProgramRequestModel
    {
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public IReadOnlyList<Question> Questions {get;set;} 

    }
    public record UpdateApplicationProgramRequestModel
    {
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public IReadOnlyList<Question> Questions {get;set;} 

    }
}