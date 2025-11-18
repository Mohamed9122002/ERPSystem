using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.DepartmentDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.Profiles
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentDto>().ForMember(dest => dest.DateOfCreation,opt => opt.MapFrom(src =>
                               src.CreatedOn.HasValue
                                   ? DateOnly.FromDateTime(src.CreatedOn.Value)
                                   : (DateOnly?)null)).ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.FullName : null));
            CreateMap<Department, DepartmentDetailsDto>().ForMember(dest => dest.DateOfCreation,opt => opt.MapFrom(src =>
                               src.CreatedOn.HasValue
                                   ? DateOnly.FromDateTime(src.CreatedOn.Value)
                                   : (DateOnly?)null));
            CreateMap<CreatedDepartmentDto, Department>().ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src =>
                     src.DateOfCreation.HasValue
                         ? src.DateOfCreation.Value.ToDateTime(TimeOnly.MinValue)
                         : (DateTime?)null));
            CreateMap<UpdatedDepartmentDto, Department>()
        .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src =>
            src.CreateOn.HasValue
                ? src.CreateOn.Value.ToDateTime(new TimeOnly(0, 0))
                : (DateTime?)null
        ));

            CreateMap<DateTime, DateOnly>()
                     .ConvertUsing(src => DateOnly.FromDateTime(src));
        }
    }
}
