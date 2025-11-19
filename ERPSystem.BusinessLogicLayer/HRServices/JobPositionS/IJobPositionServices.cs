using ERPSystem.BusinessLogicLayer.DataTransferObject.JobPositionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.JobPositionS
{
    public interface IJobPositionServices
    {
        // Create a new JobPosition
        Task<int> CreateJobPositionAsync(CreatedJobPositionDto dto);

        // Update an existing JobPosition
        Task<int> UpdateJobPositionAsync(UpdatedJobPositionDto dto);

        // Get JobPosition details by Id
        Task<JobPositionDetailsDto?> GetJobPositionByIdAsync(int id);
        Task<IEnumerable<JobPositionListDto>> GetAllJobPositionsAsync();

        // Delete a JobPosition
        Task<bool> DeleteJobPositionAsync(int id);
    }
}
