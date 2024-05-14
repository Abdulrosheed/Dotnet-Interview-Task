using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Contracts;
using DotnetInterviewTask.Dtos;
using DotnetInterviewTask.Enums;
using DotnetInterviewTask.Implementations;
using DotnetInterviewTask.Models;
using DotnetInterviewTask.ValueObjects;
using FluentAssertions;
using Mapster;
using Moq;
using Xunit;

namespace DotnetInterviewTask.UnitTests
{
    public class CreateApplicationResponseHandlerTest
    {
        private readonly Mock<IApplicationResponseRepository> _applicationResponseRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IApplicationResponseService _handler;

        public CreateApplicationResponseHandlerTest()
        {
            _applicationResponseRepositoryMock = new Mock<IApplicationResponseRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new ApplicationResponseService(_applicationResponseRepositoryMock.Object, _unitOfWorkMock.Object);
        }
        [Fact]
        public async Task Create_ApplicationResponse_Returns_Valid_Created_Response()
        {
            // Arrange
            var response = new ApplicationResponse
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@gmail.com",
                PhoneNumber = "915432176",
                Gender = Enums.Gender.Female,
                DateOfBirth = DateTime.MaxValue,
                Responses = [new (ApplicationQuestionType.Paragraph,"What is your age", "16"), new(ApplicationQuestionType.Paragraph,"What is your occupation", "Software Engineer")]
            };
            _applicationResponseRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<ApplicationResponse>())).ReturnsAsync(response);
            _unitOfWorkMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
            // Act
            var result = await _handler.CreateAsync(It.IsAny<CreateApplicationResponseRequestModel>());

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(response.Adapt<ApplicationResponseDto>());

            _applicationResponseRepositoryMock.Verify(r => r.CreateAsync(It.IsAny<ApplicationResponse>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }


    }
}