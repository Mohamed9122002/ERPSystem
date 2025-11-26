using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.Profiles
{
    public class PayrollItemMappingProfile : Profile
    {
        public PayrollItemMappingProfile()
        {
            CreateMap<PayrollItem, PayrollItemDto>()
            .ForMember(dest => dest.PayrollItemTypeName, opt => opt.MapFrom(src => src.PayrollItemType.Name))
            .ForMember(dest => dest.IsPercentage, opt => opt.MapFrom(src => src.PayrollItemType.IsPercentage))
            .ForMember(dest => dest.FixedAmount, opt => opt.MapFrom(src => src.PayrollItemType.FixedAmount))
            .ForMember(dest => dest.Percentage, opt => opt.MapFrom(src => src.PayrollItemType.Percentage));
            // Create
            CreateMap<CreatePayrollItemDto, PayrollItem>();

            // Update
            CreateMap<UpdatePayrollItemDto, PayrollItem>();
        }
    }
}
