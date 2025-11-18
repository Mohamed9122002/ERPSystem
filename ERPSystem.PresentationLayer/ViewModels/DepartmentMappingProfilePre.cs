using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.DepartmentDtos;

namespace ERPSystem.PresentationLayer.ViewModels
{
    public class DepartmentMappingProfilePre :Profile
    {
        public DepartmentMappingProfilePre()
        {
            CreateMap<DepartmentDetailsDto, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, CreatedDepartmentDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<DepartmentViewModel, UpdatedDepartmentDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreateOn, opt => opt.MapFrom(src => src.DateOfCreation));
        }
    }
}
