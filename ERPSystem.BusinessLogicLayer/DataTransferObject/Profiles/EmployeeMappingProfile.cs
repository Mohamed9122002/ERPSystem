using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.Profiles
{
    public class EmployeeMappingProfile :Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<CreatedEmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
            .ForMember(dest => dest.JobPositionName, opt => opt.MapFrom(src => src.JobPosition.Title))
            .ForMember(dest => dest.ShiftName, opt => opt.MapFrom(src => src.Shift != null ? src.Shift.Name : null));
            CreateMap<Employee, EmployeeDetailsDto>()
            .ForMember(dest => dest.DepartmentName,
                       opt => opt.MapFrom(src => src.Department.Name))
            .ForMember(dest => dest.JobPositionName,
                       opt => opt.MapFrom(src => src.JobPosition.Title))
            .ForMember(dest => dest.ShiftName,
                       opt => opt.MapFrom(src => src.Shift != null ? src.Shift.Name : null))
            .ForMember(dest => dest.EmployeeType,
                       opt => opt.MapFrom(src => src.Contract.ContractType ))
            .ForMember(dest => dest.ContractStartDate,
                       opt => opt.MapFrom(src =>  src.Contract.StartDate ))
            .ForMember(dest => dest.ContractEndDate,
                       opt => opt.MapFrom(src => src.Contract != null ? src.Contract.EndDate : null));
            CreateMap<UpdatedEmployeeDto, Employee>()
            .ForAllMembers(opts => opts.Condition(
             (src, dest, srcMember) => srcMember != null));
        }
    }
}
