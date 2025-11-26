using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Modules.HR.enums;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using ERPSystem.DataAccessLayer.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.PayrollItemS
{
    public class PayrollItemService(IUnitOfWork unitOfWork, IMapper mapper) : IPayrollItemService
    {
        IGenericRepository<PayrollItem, int> repository = unitOfWork.CreateGenericRepository<PayrollItem, int>();
        IGenericRepository<PayrollItemType, int> repositoryPayrollItemType = unitOfWork.CreateGenericRepository<PayrollItemType, int>();

        IGenericRepository<Employee, int> repositoryEmployee = unitOfWork.CreateGenericRepository<Employee, int>();

        public async Task<int> AddPayrollItemToEmployeeAsync(CreatePayrollItemDto payrollItemDto)
        {
            var employee = await repositoryEmployee.GetByIdAsync(payrollItemDto.EmployeeId);
            if (employee is null)
                throw new Exception("Employee not found");
            var payrollItemType = await repositoryPayrollItemType.GetByIdAsync(payrollItemDto.PayrollItemTypeId);
            if (payrollItemType is null)
                throw new Exception("Payroll Item Type not found");
            var payrollItem = mapper.Map<PayrollItem>(payrollItemDto);
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
            var payrollItems = await repository.GetAllAsync();
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
        public async Task<decimal> CalculateNetSalaryAsync(int employeeId)
        {
            decimal allowances = 0;
            decimal deductions = 0;
            var employee = await repositoryEmployee.GetByIdAsync(employeeId);
            if (employee is null)
                throw new Exception("Employee not found");
            var payrollItems = await repository.GetAllAsync();
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
