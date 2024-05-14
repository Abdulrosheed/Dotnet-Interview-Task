using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Enums;

namespace DotnetInterviewTask.ValueObjects
{
    public class Response
    {
        public string QuestionText {get; private set;}
        public string ResponseText {get; private set;}
        public ApplicationQuestionType QuestionType { get; private set; }
        public Response(ApplicationQuestionType questionType, string questionText, string responseText)
        {
            QuestionType = questionType;
            QuestionText = questionText;
            ResponseText = responseText;
        }
        
    }
}