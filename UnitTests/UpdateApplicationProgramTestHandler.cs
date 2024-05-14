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
    public class UpdateApplicationProgramTestHandler
    {
        private readonly Mock<IApplicationProgramRepository> _applicationProgramRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IApplicationProgramService _handler;

        public UpdateApplicationProgramTestHandler()
        {
            _applicationProgramRepositoryMock = new Mock<IApplicationProgramRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new ApplicationProgramService(_applicationProgramRepositoryMock.Object, _unitOfWorkMock.Object);
        }
        [Fact]
        public async Task Update_ApplicationProgram_With_Valid_Id_Returns_Valid_Sucess_Response()
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
            var request = new UpdateApplicationProgramRequestModel
            {
                ProgramTitle = "New-Test-Program",
                ProgramDescription = "New-Test-Program",
                Questions = new List<Question>{
                    new (Enums.ApplicationQuestionType.Date, "What is your date of birth "),
                }
            };

            _applicationProgramRepositoryMock.Setup(r => r.GetAsync(It.IsAny<Guid>())).ReturnsAsync(response);
            _applicationProgramRepositoryMock.Setup(r => r.Update(It.IsAny<ApplicationProgram>())).Returns(request.Adapt(response));
            // Act
            var result = await _handler.Update(It.IsAny<Guid>(), It.IsAny<UpdateApplicationProgramRequestModel>());

            // Assert
            var expectedResponse = request.Adapt<ApplicationProgramDto>();
            expectedResponse.Id = response.Id;
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResponse);

            _applicationProgramRepositoryMock.Verify(r => r.GetAsync(It.IsAny<Guid>()), Times.Once);
            _applicationProgramRepositoryMock.Verify(r => r.Update(It.IsAny<ApplicationProgram>()), Times.Once);
            _unitOfWorkMock.Verify(r => r.SaveChangesAsync(), Times.Once);

        }
        [Fact]
        public async Task Update_ApplicationProgram_With_InValid_Id_Throws_Exception()
        {
            // Arrange
            _applicationProgramRepositoryMock.Setup(r => r.GetAsync(It.IsAny<Guid>())).ReturnsAsync((ApplicationProgram)default);
            // Act
            Func<Task> func = async () => await _handler.Update(It.IsAny<Guid>(), It.IsAny<UpdateApplicationProgramRequestModel>());
            // Assert
            await func.Should().ThrowAsync<ArgumentNullException>();
            _applicationProgramRepositoryMock.Verify(r => r.GetAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}