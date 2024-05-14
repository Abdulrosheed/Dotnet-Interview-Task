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
    public class ApplicationProgramService(IApplicationProgramRepository applicationProgramRepository, IUnitOfWork unitOfWork) : IApplicationProgramService
    {
        private readonly IApplicationProgramRepository _applicationProgramRepository = applicationProgramRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ApplicationProgramDto> CreateAsync(CreateApplicationProgramRequestModel requestModel)
        {
            var applicationProgram = requestModel.Adapt<ApplicationProgram>();
            var createdApplicationProgram =   await _applicationProgramRepository.CreateAsync(applicationProgram);
            await _unitOfWork.SaveChangesAsync();
            return createdApplicationProgram.Adapt<ApplicationProgramDto>();
        }

        public async Task<IReadOnlyList<ApplicationProgramDto>> GetAllAsync()
        {
            var applicationPrograms = await _applicationProgramRepository.GetAllAsync();
            return applicationPrograms.Adapt<IReadOnlyList<ApplicationProgramDto>>();
        }

        public async Task<ApplicationProgramDto?> GetAsync(Guid id)
        {
            var applicationProgram = await _applicationProgramRepository.GetAsync(id);
            return applicationProgram.Adapt<ApplicationProgramDto>();
        }

        public async Task<ApplicationProgramDto>  Update(Guid id, UpdateApplicationProgramRequestModel requestModel)
        {
            var applicationProgram = await _applicationProgramRepository.GetAsync(id);
            if(applicationProgram is null)
            {
                throw new ArgumentNullException($"Record with id: {id} cannot be found");
            }
            requestModel.Adapt(applicationProgram);
            _applicationProgramRepository.Update(applicationProgram);
            await _unitOfWork.SaveChangesAsync();
            return applicationProgram.Adapt<ApplicationProgramDto>();

        }
    }
}