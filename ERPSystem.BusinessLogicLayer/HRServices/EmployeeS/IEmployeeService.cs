using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.EmployeeS
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(string? employeeSearchName);

        Task<EmployeeDetailsDto?> GetEmployeeByIdAsync(int id);

        Task<int> CreateEmployeeAsync(CreatedEmployeeDto employeeDto);

        Task<int> UpdateEmployeeAsync(UpdatedEmployeeDto employeeDto);

        Task<bool> DeleteEmployeeAsync(int id);
    }
}
