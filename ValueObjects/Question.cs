using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Enums;

namespace DotnetInterviewTask.ValueObjects
{
    public class Question
    {
        public string QuestionText {get; private set;}
        public ApplicationQuestionType QuestionType { get; private set; }
        private readonly List<string> _choices = new();
        public Question(ApplicationQuestionType questionType, string questionText, IReadOnlyList<string>? choices = null)
        {
            QuestionType = questionType;
            QuestionText = questionText;
            if (choices is not null)
            {
                _choices = new List<string>(choices);
            }
        }
        public IReadOnlyList<string> Choices
        {
            get => _choices.AsReadOnly();
            private set => _choices.AddRange(value);
        }
    }
}