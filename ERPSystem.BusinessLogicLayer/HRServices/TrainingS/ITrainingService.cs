using ERPSystem.BusinessLogicLayer.DataTransferObject.TrainingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.TrainingS
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingListDto>> GetAllTrainingsAsync();
        Task<TrainingDetailsDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateTrainingDto  trainingDto);
        Task<int> UpdateAsync(UpdateTrainingDto  trainingDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> AssignEmployeesAsync(AssignEmployeeToTrainingDto trainingDto);
    }
}
