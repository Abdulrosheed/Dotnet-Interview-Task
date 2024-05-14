using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.ValueObjects;

namespace DotnetInterviewTask.Models
{
    public class ApplicationProgram
    {
        public Guid Id {get;  set;} = Guid.NewGuid();
        public string ProgramTitle { get;  set; }
        public string ProgramDescription { get;  set; } 
        public IReadOnlyList<Question> Questions {get;set;}
    }
}