using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.JobPositionDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.Profiles
{
    public class JobPositionMappingProfile:Profile
    {
        public JobPositionMappingProfile()
        {
            // Entity -> Details DTO
            CreateMap<JobPosition, JobPositionDetailsDto>()
                .ForMember(dest => dest.DepartmentName,
                           opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : null));

            // Entity -> List DTO
            CreateMap<JobPosition, JobPositionListDto>()
                .ForMember(dest => dest.DepartmentName,
                           opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : null));
            CreateMap<CreatedJobPositionDto, JobPosition>().ReverseMap();
            CreateMap<UpdatedJobPositionDto, JobPosition>().ReverseMap();

            //// ViewModel -> Created DTO
            //CreateMap<JobPositionViewModel, CreatedJobPositionDto>()
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //    .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));

            //// ViewModel -> Updated DTO
            //CreateMap<JobPositionViewModel, UpdatedJobPositionDto>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //    .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}
