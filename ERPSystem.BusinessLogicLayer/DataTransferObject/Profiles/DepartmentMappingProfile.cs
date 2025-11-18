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
            CreateMap<Department, DepartmentDto>()
           .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.FullName : null));
            CreateMap<Department, DepartmentDetailsDto>();
            CreateMap<CreatedDepartmentDto, Department>();
            CreateMap<UpdatedDepartmentDto, Department>()
                .ForMember(dest => dest.CreatedOn, opt =>
                opt.MapFrom(src => src.CreateOn.ToDateTime(new TimeOnly(0, 0))));


        }
    }
}
