using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemTypeDtos;
using ERPSystem.PresentationLayer.ViewModels.Payroll_temType;

namespace ERPSystem.PresentationLayer.ViewModels.Profiles
{
    public class PayrollItemTypeMappingProfilePre:Profile
    {
        public PayrollItemTypeMappingProfilePre()
        {
            CreateMap<PayrollItemTypeViewModel, CreatePayrollItemTypeDto>();
            CreateMap<PayrollItemTypeViewModel, UpdatePayrollItemTypeDto>();
            CreateMap<PayrollItemTypeDto, PayrollItemTypeViewModel>().ReverseMap();
        }
    }
}
