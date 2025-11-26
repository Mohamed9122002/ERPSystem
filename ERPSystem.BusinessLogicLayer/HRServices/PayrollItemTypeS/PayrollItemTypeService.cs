using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemTypeDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using ERPSystem.DataAccessLayer.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.HRServices.PayrollItemTypeS
{
    public class PayrollItemTypeService(IUnitOfWork unitOfWork, IMapper mapper) : IPayrollItemTypeService
    {
        IGenericRepository<PayrollItemType, int> repository = unitOfWork.CreateGenericRepository<PayrollItemType, int>();
        public async Task<List<PayrollItemTypeDto>> GetAllPayrollItemType()
        {
            var payrollItemTypes = await repository.GetAllAsync();
            var payrollItemTypeDtos = mapper.Map<List<PayrollItemTypeDto>>(payrollItemTypes);
            return payrollItemTypeDtos;
        }

        public async Task<PayrollItemTypeDto?> GetPayrollItemTypeById(int id)
        {
            var payrollItemType = await repository.GetByIdAsync(id);
            if (payrollItemType is null)
                return null;

            var payrollItemTypeDto = mapper.Map<PayrollItemTypeDto>(payrollItemType);

            return payrollItemTypeDto;
        }
        public async Task<int> CreatePayrollItemType(CreatePayrollItemTypeDto payrollItemTypeDto)
        {
            var payrollItemType = mapper.Map<PayrollItemType>(payrollItemTypeDto);
            await repository.AddAsync(payrollItemType);
            return await unitOfWork.SaveChangeAsync();
        }
        public async Task<int> UpdatePayrollItemType(UpdatePayrollItemTypeDto payrollItemTypeDto)
        {
            var payrollItemType = mapper.Map<PayrollItemType>(payrollItemTypeDto);
            repository.Update(payrollItemType);
            return await unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var payrollItemType = await repository.GetByIdAsync(id);
            if (payrollItemType is null)
                throw new Exception($"Payroll Item Type {id} not found.");
            repository.Remove(payrollItemType);
            var result = await unitOfWork.SaveChangeAsync();
            return result > 0 ? true : false;
        }
    }
}
