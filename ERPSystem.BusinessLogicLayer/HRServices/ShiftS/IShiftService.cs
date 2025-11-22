using ERPSystem.BusinessLogicLayer.DataTransferObject.ShiftDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.ShiftS
{
    public interface IShiftService
    {
        Task<int> CreateShiftAsync(CreateShiftDto createShiftDto);
        Task<int> UpdateShiftAsync(UpdateShiftDto updateShiftDto);
        Task<bool> DeleteShiftAsync(int id);
        Task<IEnumerable<ShiftDto>> GetAllShiftsAsync();
        Task<ShiftDto?> GetShiftByIdAsync(int id);
        //AssignEmployeesToShift
        Task<bool>AssignEmployeesToShiftAsync(int shiftId , List<int> employeesId);
        Task<bool>RemoveEmployeeToShiftAsync(int shiftId , int employeeId);
    }
}
