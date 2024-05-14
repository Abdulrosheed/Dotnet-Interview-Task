using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Enums;
using DotnetInterviewTask.ValueObjects;

namespace DotnetInterviewTask.Dtos
{
    public record ApplicationResponseDto
    {
        public Guid Id {get; set;}
        public string FirstName {get; set;} = default!;
        public string LastName {get; set;} = default!;
        public string Email {get; set;} = default!;
        public string PhoneNumber {get; set;}
        public string Nationality {get; set;}
        public string IDNumber {get; set;}
        public DateTime DateOfBirth {get; set;}
        public Gender Gender {get; set;}
        public IReadOnlyList<Response> Responses {get;set;}
    }
    public record CreateApplicationResponseRequestModel
    {
        public string FirstName {get; set;} = default!;
        public string LastName {get; set;} = default!;
        public string Email {get; set;} = default!;
        public string PhoneNumber {get; set;}
        public string Nationality {get; set;}
        public string IDNumber {get; set;}
        public DateTime DateOfBirth {get; set;}
        public Gender Gender {get; set;}
        public IReadOnlyList<Response> Responses {get;set;}
    }
}