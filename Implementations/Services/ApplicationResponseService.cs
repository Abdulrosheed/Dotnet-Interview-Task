using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Contracts;
using DotnetInterviewTask.Dtos;
using DotnetInterviewTask.Models;
using Mapster;

namespace DotnetInterviewTask.Implementations
{
    public class ApplicationResponseService(IApplicationResponseRepository applicationResponseRepository, IUnitOfWork unitOfWork) : IApplicationResponseService
    {
        private readonly IApplicationResponseRepository _applicationResponseRepository = applicationResponseRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ApplicationResponseDto> CreateAsync(CreateApplicationResponseRequestModel requestModel)
        {
            var applicationResponse = requestModel.Adapt<ApplicationResponse>();
            var createdApplicationResponse = await _applicationResponseRepository.CreateAsync(applicationResponse);
            await _unitOfWork.SaveChangesAsync();
            return createdApplicationResponse.Adapt<ApplicationResponseDto>();
        }
    }
}