using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.TrainingDtos;
using ERPSystem.BusinessLogicLayer.Specifications;
using ERPSystem.DataAccessLayer.Contexts;
using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using ERPSystem.DataAccessLayer.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.TrainingS
{
    public class TrainingService(IUnitOfWork _unitOfWork ,IMapper _mapper) : ITrainingService
    {
        TrainingTypeSpecifications trainingSpecifications;

        IGenericRepository<Training, int> trainingRepository = _unitOfWork.CreateGenericRepository<Training, int>();
        public async Task<IEnumerable<TrainingListDto>> GetAllTrainingsAsync()
        {
            IEnumerable<Training>  training;
            trainingSpecifications = new TrainingTypeSpecifications();
             training =  await trainingRepository.GetAllAsync(trainingSpecifications);
            var trainingDtos = _mapper.Map<IEnumerable<TrainingListDto>>(training);
            return trainingDtos;
        }

        public async Task<TrainingDetailsDto?> GetByIdAsync(int id)
        {
            var specifications = new TrainingTypeSpecifications(id);
            var training = await  trainingRepository.GetByIdAsync(specifications);
            var trainingDto = _mapper.Map<TrainingDetailsDto>(training);
            return training == null ? null : trainingDto;
        }

        public async Task<int> CreateAsync(CreateTrainingDto  trainingDto)
        {
            var training = _mapper.Map<CreateTrainingDto,Training>(trainingDto);
           await  trainingRepository.AddAsync(training);
            return await _unitOfWork.SaveChangeAsync();
        }
        public async Task<int> UpdateAsync(UpdateTrainingDto  trainingDto)
        {
            var trainning = _mapper.Map<UpdateTrainingDto,Training>(trainingDto);
             trainingRepository.Update(trainning);
            return await _unitOfWork.SaveChangeAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var training = await trainingRepository.GetByIdAsync(id);
            if (training is null) return false;
            else
            {
                training.IsDeleted = true;
                trainingRepository.Remove(training);

                return await _unitOfWork.SaveChangeAsync() > 0 ? true : false;
            }
            ;
        }
        public async Task<bool> AssignEmployeesAsync(AssignEmployeeToTrainingDto trainingDto)
        {
            var training = await trainingRepository.GetByIdAsync(new TrainingTypeSpecifications(trainingDto.TrainingId));
            if (training == null) return false;

            var toRemove = training.EmployeeTrainings
                .Where(et => !trainingDto.EmployeeIds.Contains(et.EmployeeId))
                .ToList();
            foreach (var item in toRemove)
                training.EmployeeTrainings.Remove(item);

            foreach (var empId in trainingDto.EmployeeIds)
            {
                if (!training.EmployeeTrainings.Any(et => et.EmployeeId == empId))
                {
                    training.EmployeeTrainings.Add(new EmployeeTraining
                    {
                        EmployeeId = empId,
                        TrainingId = training.Id
                    });
                }
            }

            return await _unitOfWork.SaveChangeAsync() > 0;
        }

    }
}
