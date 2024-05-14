using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Contracts;
using DotnetInterviewTask.Dtos;
using DotnetInterviewTask.Implementations;
using DotnetInterviewTask.Models;
using DotnetInterviewTask.ValueObjects;
using FluentAssertions;
using Mapster;
using Moq;
using Xunit;

namespace DotnetInterviewTask.UnitTests
{
    public class GetAllApplicationProgramHandlerTest
    {
        private readonly Mock<IApplicationProgramRepository> _applicationProgramRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IApplicationProgramService _handler;

        public GetAllApplicationProgramHandlerTest()
        {
            _applicationProgramRepositoryMock = new Mock<IApplicationProgramRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new ApplicationProgramService(_applicationProgramRepositoryMock.Object, _unitOfWorkMock.Object);
        }
        [Fact]
        public async Task GetAll_ApplicationProgram_Returns_Valid_Sucess_Response()
        {
            // Arrange
            var response = new List<ApplicationProgram>
            {
                new (){
                    ProgramTitle = "Test-Program",
                    ProgramDescription = "Test-Program",
                    Questions = new List<Question>
                    {
                        new (Enums.ApplicationQuestionType.Paragraph, "What is your age "),
                        new (Enums.ApplicationQuestionType.Dropdown , "Who is the greatest footballer of all time" , ["Ronaldo", "Messi", "Ronaldinho", "Maradona"])
                    }
                },
                new (){
                    ProgramTitle = "Test-Program-2",
                    ProgramDescription = "Test-Program-2",
                    Questions = new List<Question>
                    {
                        new (Enums.ApplicationQuestionType.YesNo, "Are you schooling"),
                        new (Enums.ApplicationQuestionType.MultipleChoice , "Select  your favourite food" , ["Garri", "Beans", "Rice", "Yam"])
                    }
                }
                
            };
            _applicationProgramRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(response);
            // Act
            var result = await _handler.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(response.Adapt<List<ApplicationProgramDto>>());

            _applicationProgramRepositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
        }
    }
}