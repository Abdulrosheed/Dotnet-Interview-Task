using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Enums;
using DotnetInterviewTask.ValueObjects;

namespace DotnetInterviewTask.Models
{
    public class ApplicationResponse
    {
        public Guid Id {get;  set;} = Guid.NewGuid();
        public string FirstName {get;  set;} = default!;
        public string LastName {get;  set;} = default!;
        public string Email {get;  set;} = default!;
        public string PhoneNumber {get;  set;}
        public string Nationality {get;  set;}
        public string IDNumber {get;  set;}
        public DateTime DateOfBirth {get;  set;}
        public Gender Gender {get;  set;}
        public IReadOnlyList<Response> Responses {get;set;}
        
    }
}