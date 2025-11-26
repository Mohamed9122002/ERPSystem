using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemTypeDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.Profiles
{
    public class PayrollItemTypeMappingProfile :Profile
    {
        public PayrollItemTypeMappingProfile()
        {
            CreateMap<PayrollItemType, PayrollItemTypeDto>(); 
            CreateMap<CreatePayrollItemTypeDto, PayrollItemType>();
            CreateMap<UpdatePayrollItemTypeDto, PayrollItemType>();
        }
    }
}
