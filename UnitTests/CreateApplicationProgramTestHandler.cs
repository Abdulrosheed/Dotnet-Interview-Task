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
    public class CreateApplicationProgramHandlerTest
    {
        private readonly Mock<IApplicationProgramRepository> _applicationProgramRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IApplicationProgramService _handler;

        public CreateApplicationProgramHandlerTest()
        {
            _applicationProgramRepositoryMock = new Mock<IApplicationProgramRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new ApplicationProgramService(_applicationProgramRepositoryMock.Object, _unitOfWorkMock.Object);
        }
        [Fact]
        public async Task Create_ApplicationProgram_Returns_Valid_Created_Response()
        {
            // Arrange
            var response = new ApplicationProgram
            {
                ProgramTitle = "Test-Program",
                ProgramDescription = "Test-Program",
                Questions = new List<Question>{
                new (Enums.ApplicationQuestionType.Paragraph, "What is your age "),
                new (Enums.ApplicationQuestionType.Dropdown , "Who is the greatest footballer of all time" , ["Ronaldo", "Messi", "Ronaldinho", "Maradona"])
            }
            };
            _applicationProgramRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<ApplicationProgram>())).ReturnsAsync(response);
            _unitOfWorkMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
            // Act
            var result = await _handler.CreateAsync(It.IsAny<CreateApplicationProgramRequestModel>());

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(response.Adapt<ApplicationProgramDto>());

            _applicationProgramRepositoryMock.Verify(r => r.CreateAsync(It.IsAny<ApplicationProgram>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }


    }
}