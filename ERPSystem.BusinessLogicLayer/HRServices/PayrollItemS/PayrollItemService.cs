using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;
using ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemDtos;
using ERPSystem.BusinessLogicLayer.Specifications;
using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Modules.HR.enums;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using ERPSystem.DataAccessLayer.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ERPSystem.BusinessLogicLayer.HRServices.PayrollItemS
{
    public class PayrollItemService(IUnitOfWork unitOfWork, IMapper mapper) : IPayrollItemService
    {
         PayrollItemWithTypeSpecification spec = new PayrollItemWithTypeSpecification();
        IGenericRepository<PayrollItem, int> repository = unitOfWork.CreateGenericRepository<PayrollItem, int>();
        IGenericRepository<PayrollItemType, int> repositoryPayrollItemType = unitOfWork.CreateGenericRepository<PayrollItemType, int>();
        IGenericRepository<Employee, int> repositoryEmployee = unitOfWork.CreateGenericRepository<Employee, int>();
        IGenericRepository<Attendance, int> repositoryAttendance = unitOfWork.CreateGenericRepository<Attendance, int>();

        public async Task<int> AddPayrollItemToEmployeeAsync(CreatePayrollItemDto payrollItemDto)
        {
            var employee = await repositoryEmployee.GetByIdAsync(payrollItemDto.EmployeeId);
            if (employee is null)
                throw new Exception("Employee not found");
            var payrollItemType = await repositoryPayrollItemType.GetByIdAsync(payrollItemDto.PayrollItemTypeId);
            if (payrollItemType is null)
                throw new Exception("Payroll Item Type not found");
            var payrollItem = mapper.Map<PayrollItem>(payrollItemDto);
            /////
            payrollItem.Amount = CalculateItemAmount(payrollItemType, employee.Salary);
            payrollItem.StartDate = DateTime.Now;
            payrollItem.IsActive = true;
            await repository.AddAsync(payrollItem);
            return await unitOfWork.SaveChangeAsync();
        }
        public async Task<int> UpdatePayrollItemAsync(UpdatePayrollItemDto payrollItemDto)
        {
            var payrollItem = await repository.GetByIdAsync(payrollItemDto.Id);
            if (payrollItem is null)
                throw new Exception("Payroll item not found");
            var payroll = mapper.Map(payrollItemDto, payrollItem);
            repository.Update(payroll);
            return await unitOfWork.SaveChangeAsync();
        }
        public async Task<bool> DeletePayrollItemAsync(int id)
        {
            var payrollItem = await repository.GetByIdAsync(id);
            if (payrollItem is null)
                throw new Exception($"Payroll Item  {id} not found.");
            repository.Remove(payrollItem);
            var result = await unitOfWork.SaveChangeAsync();
            return result > 0 ? true : false;
        }

        public async Task<IEnumerable<PayrollItemDto>> GetPayrollItemAllAsync()
        {
            var payrollItems = await repository.GetAllAsync(spec);
            var payrollItemDtos = mapper.Map<IEnumerable<PayrollItem>, IEnumerable<PayrollItemDto>>(payrollItems);
            return payrollItemDtos;
        }

        public async Task<PayrollItemDto?> GetPayrollItemByIdAsync(int id)
        {
            var payrollItem = await repository.GetByIdAsync(id);

            if (payrollItem is null)
                throw new Exception($"Payroll Item  {id} not found.");
            var payrollItemDto = mapper.Map<PayrollItemDto>(payrollItem);
            return payrollItemDto;
        }
        #region Attendance → PayrollItems
        public async Task<int> GeneratePayrollItemsFromAttendanceAsync(int employeeId, DateTime month)
        {
            int addedItems = 0;
            var employee = await repositoryEmployee.GetByIdAsync(employeeId) ?? throw new Exception("Employee not found");
            var attandanceSpec = new AttendanceWithEmployeeSpecification(employeeId, month);
            var attandances = await repositoryAttendance.GetAllAsync(attandanceSpec);
            foreach (var attendance in attandances)
            {

                // Absence Deduction
                if (attendance.IsAbsent)
                    addedItems += await AddAttendancePayrollItem(employee, "Absence", PayrollItemKind.Deduction, attendance.Date, 1);

                // Late Deduction
                if (attendance.LateHours > 0)
                    addedItems += await AddAttendancePayrollItem(employee, "Late", PayrollItemKind.Deduction, attendance.Date, attendance.LateHours);

                // Overtime Allowance
                if (attendance.OvertimeHours > 0)
                    addedItems += await AddAttendancePayrollItem(employee, "Overtime", PayrollItemKind.Allowance, attendance.Date, attendance.OvertimeHours);
            }
            return await unitOfWork.SaveChangeAsync();

        }
        private async Task<int> AddAttendancePayrollItem(Employee employee, string typeName, PayrollItemKind kind, DateTime date, decimal multiplier)
        {
            var type = (await repositoryPayrollItemType.GetAllAsync()).FirstOrDefault(t => t.Kind == kind && t.Name.Contains(typeName));
            if (type == null) return 0;

            var payrollItem = new PayrollItem
            {
                EmployeeId = employee.Id,
                PayrollItemTypeId = type.Id,
                Amount = (type.IsPercentage ? (employee.Salary * (type.Percentage ?? 0) / 100m)
                                            : type.FixedAmount ?? 0) * multiplier,
                StartDate = date,
                IsActive = true
            };
            await repository.AddAsync(payrollItem);
            return 1;
        }
        #endregion
        public async Task<decimal> CalculateNetSalaryAsync(int employeeId , DateTime month)
        {
            await GeneratePayrollItemsFromAttendanceAsync(employeeId, month);
            decimal allowances = 0;
            decimal deductions = 0;
            var employee = await repositoryEmployee.GetByIdAsync(employeeId);
            if (employee is null)
                throw new Exception("Employee not found");
            var payrollItems = await repository.GetAllAsync(spec);
            foreach (var payrollItem in payrollItems.Where(P => P.IsActive))
            {
                var type = payrollItem.PayrollItemType;
                if (type == null)
                    throw new Exception("Payroll Item Type not found");
                var amount = CalculateItemAmount(type, employee.Salary);
                if (type.Kind == PayrollItemKind.Allowance)
                    allowances += amount;
                else
                    deductions += amount;
            }
            return employee.Salary + allowances - deductions;
        }
        private decimal CalculateItemAmount(PayrollItemType itemType, decimal basicSalary)
        {
            if (itemType.IsPercentage)
            {
                if (itemType.Percentage == null)
                    throw new Exception("Percentage is missing for this type");

                return (basicSalary * itemType.Percentage.Value) / 100m;
            }
            else
            {
                if (itemType.FixedAmount == null)
                    throw new Exception("Fixed amount is missing for this type");
                return itemType.FixedAmount.Value;
            }
        }


    }
}
