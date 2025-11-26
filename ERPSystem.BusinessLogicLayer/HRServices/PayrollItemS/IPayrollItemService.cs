using ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemDtos;
using ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemTypeDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.PayrollItemS
{
    public interface IPayrollItemService
    {
        Task<IEnumerable<PayrollItemDto>> GetPayrollItemAllAsync();
        Task<PayrollItemDto?> GetPayrollItemByIdAsync(int id);
        Task<int> AddPayrollItemToEmployeeAsync(CreatePayrollItemDto payrollItemDto);
        Task<int> UpdatePayrollItemAsync(UpdatePayrollItemDto payrollItemDto);
        Task<bool> DeletePayrollItemAsync(int id);
        Task<decimal> CalculateNetSalaryAsync(int employeeId);
    }
}
