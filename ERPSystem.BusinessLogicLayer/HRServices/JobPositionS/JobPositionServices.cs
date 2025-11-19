using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.DepartmentDtos;
using ERPSystem.BusinessLogicLayer.DataTransferObject.JobPositionDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using ERPSystem.DataAccessLayer.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.JobPositionS
{
    public class JobPositionServices(IUnitOfWork _unitOfWork, IMapper _mapper) : IJobPositionServices
    {
        IGenericRepository<JobPosition, int> repo = _unitOfWork.CreateGenericRepository<JobPosition, int>();

        public async Task<int> CreateJobPositionAsync(CreatedJobPositionDto dto)
        {
            var jobPos = _mapper.Map<CreatedJobPositionDto, JobPosition>(dto);
            await repo.AddAsync(jobPos);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteJobPositionAsync(int id)
        {
            var jobPos = await repo.GetByIdAsync(id);
            if (jobPos == null)
                throw new Exception($"JobPos with Id {id} not found.");
            repo.Remove(jobPos);
            var result = await _unitOfWork.SaveChangeAsync();
            return result > 0 ? true : false;
        }

        public async Task<IEnumerable<JobPositionListDto>> GetAllJobPositionsAsync()
        {
            IEnumerable<JobPosition> AllJobPositions = await repo.GetAllAsync();
            return _mapper.Map<IEnumerable<JobPosition>, IEnumerable<JobPositionListDto>>(AllJobPositions);

        }

        public async Task<JobPositionDetailsDto?> GetJobPositionByIdAsync(int id)
        {
            var jobPosition = await repo.GetByIdAsync(id);
            return _mapper.Map<JobPosition, JobPositionDetailsDto?>(jobPosition);
        }

        public async Task<int> UpdateJobPositionAsync(UpdatedJobPositionDto dto)
        {
            var JobPos = _mapper.Map<UpdatedJobPositionDto, JobPosition>(dto);
            repo.Update(JobPos);
            return await _unitOfWork.SaveChangeAsync();
        }
    }
}
