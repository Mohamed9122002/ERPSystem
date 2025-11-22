using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.ShiftDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using ERPSystem.DataAccessLayer.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.ShiftS
{
    public class ShiftService(IUnitOfWork unitOfWork, IMapper mapper) : IShiftService
    {
        IGenericRepository<Shift, int> repo = unitOfWork.CreateGenericRepository<Shift, int>();
        public async Task<int> CreateShiftAsync(CreateShiftDto createShiftDto)
        {
            var shift = mapper.Map<Shift>(createShiftDto);
            await repo.AddAsync(shift);
            return await unitOfWork.SaveChangeAsync();
        }
        public async Task<int> UpdateShiftAsync(UpdateShiftDto updateShiftDto)
        {
            var shift = mapper.Map<Shift>(updateShiftDto);
            repo.Update(shift);
            return await unitOfWork.SaveChangeAsync();
        }
        public async Task<bool> DeleteShiftAsync(int id)
        {
            var shift = await repo.GetByIdAsync(id);
            if (shift is null)
                return false;
            else
            {
                shift.IsDeleted = true;
                repo.Remove(shift);
                return await unitOfWork.SaveChangeAsync() > 0 ? true : false;
            }
        }

        public async Task<IEnumerable<ShiftDto>> GetAllShiftsAsync()
        {
            var AllShifts = await  repo.GetAllAsync();
            return mapper.Map<IEnumerable<ShiftDto>>(AllShifts);
        }

        public async Task<ShiftDto?> GetShiftByIdAsync(int id)
        {
          var shift = await  repo.GetByIdAsync(id);
            return mapper.Map<ShiftDto?>(shift);
        }

        public Task<bool> AssignEmployeesToShiftAsync(int shiftId, List<int> employeesId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveEmployeeToShiftAsync(int shiftId, int employeeId)
        {
            throw new NotImplementedException();
        }


    }
}
