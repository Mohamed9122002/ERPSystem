using ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemTypeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.PayrollItemTypeS
{
    public interface IPayrollItemTypeService
    {
        Task<List<PayrollItemTypeDto>> GetAllPayrollItemType();
        Task<PayrollItemTypeDto> GetPayrollItemTypeById(int id);
        Task<int>  CreatePayrollItemType(CreatePayrollItemTypeDto payrollItemTypeDto);
        Task<int>  UpdatePayrollItemType(UpdatePayrollItemTypeDto payrollItemTypeDto);
        Task<bool> DeleteAsync(int id);
    }
}
