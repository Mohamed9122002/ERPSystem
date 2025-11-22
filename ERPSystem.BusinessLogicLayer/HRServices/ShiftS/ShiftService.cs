using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.ShiftDtos;
using ERPSystem.BusinessLogicLayer.Specifications;
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
        IGenericRepository<Employee, int> repositoryEmployee = unitOfWork.CreateGenericRepository<Employee, int>();

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
            var spec = new ShiftWithEmployeesByIdSpecification();
            var AllShifts = await  repo.GetAllAsync(spec);
            return mapper.Map<IEnumerable<ShiftDto>>(AllShifts);
        }

        public async Task<ShiftDto?> GetShiftByIdAsync(int id)
        {
            var spec = new ShiftWithEmployeesByIdSpecification(id);
            var shift = await  repo.GetByIdAsync(spec);
            return mapper.Map<ShiftDto?>(shift);
        }

        public async Task<bool> AssignEmployeesToShiftAsync(int shiftId, List<int> employeesId)
        {
            var spec = new ShiftWithEmployeesByIdSpecification(shiftId);
            var shift = await repo.GetByIdAsync(spec);
            if (shift == null) return false;

            var employees = await repositoryEmployee.GetAllAsync(e => employeesId.Contains(e.Id));
            foreach (var emp in employees)
            {
                if (!shift.Employees.Any(e => e.Id == emp.Id))
                {
                    shift.Employees.Add(emp);
                }
            }
            await unitOfWork.SaveChangeAsync();
            return true;
        }

        public async Task<bool> RemoveEmployeeToShiftAsync(int shiftId, int employeeId)
        {
            var spec = new ShiftWithEmployeesByIdSpecification(shiftId);
            var shift = await repo.GetByIdAsync(spec);
            if (shift == null)
                return false;
            var employeeToRemove = shift.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (employeeToRemove == null)
                return false;
            shift.Employees.Remove(employeeToRemove);
            await unitOfWork.SaveChangeAsync();
            return true;
        }


    }
}
