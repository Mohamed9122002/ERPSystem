using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using ERPSystem.DataAccessLayer.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.EmployeeS
{
    public class EmployeeService(IUnitOfWork _unitOfWork, IMapper _mapper) : IEmployeeService
    {
        IGenericRepository<Employee, int> repo = _unitOfWork.CreateGenericRepository<Employee, int>();
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(string? employeeSearchName)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrWhiteSpace(employeeSearchName))
                employees = await repo.GetAllAsync(false);
            else
                employees = await repo.GetAllAsync(E => E.FullName.ToLower().Contains(employeeSearchName.ToLower()));
            var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeesDto;
        }
        public async Task<int> CreateEmployeeAsync(CreatedEmployeeDto employeeDto)
        {
            //Convert CreateEmployeeDTO To Employee
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(employeeDto);
            await repo.AddAsync(employee);
            return await _unitOfWork.SaveChangeAsync();
        }



        public async Task<EmployeeDetailsDto?> GetEmployeeByIdAsync(int id)
        {
            var employee = await repo.GetByIdAsync(id);
            return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);
        }

        public async Task<int> UpdateEmployeeAsync(UpdatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto);
            // Update Employee In Database
            repo.Update(employee);
            return await _unitOfWork.SaveChangeAsync();
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await repo.GetByIdAsync(id);
            if (employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                // Delete Employee From Database

                repo.Update(employee);

                return await _unitOfWork.SaveChangeAsync() > 0 ? true : false;
            }
        }
    }
}
