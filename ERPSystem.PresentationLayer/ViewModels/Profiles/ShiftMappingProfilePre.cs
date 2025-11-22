using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;
using ERPSystem.BusinessLogicLayer.DataTransferObject.ShiftDtos;
using ERPSystem.DataAccessLayer.Modules.HR;

namespace ERPSystem.PresentationLayer.ViewModels.Profiles
{
    public class ShiftMappingProfilePre : Profile
    {
        public ShiftMappingProfilePre()
        {
            CreateMap<ShiftViewModel, CreateShiftDto>();
            CreateMap<ShiftViewModel, UpdateShiftDto>();
            CreateMap<ShiftDto, ShiftViewModel>();
            CreateMap<Shift, ShiftViewModel>()
                .ForMember(dest => dest.AssignedEmployees,
                   opt => opt.MapFrom(src => src.Employees))
                .ForMember(dest => dest.AllEmployees, opt => opt.Ignore());
            CreateMap<Shift, ShiftDto>()
            .ForMember(dest => dest.AssignedEmployees, opt => opt.MapFrom(src => src.Employees))
            .ForMember(dest => dest.EmployeesCount, opt => opt.Ignore());
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
