using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.DepartmentDtos;
using ERPSystem.BusinessLogicLayer.DataTransferObject.JobPositionDtos;

namespace ERPSystem.PresentationLayer.ViewModels
{
    public class JobPositionMappingProfilePre :Profile
    {
        public JobPositionMappingProfilePre()
        {
            CreateMap<JobPositionViewModel, CreatedJobPositionDto>();
            CreateMap<JobPositionViewModel, UpdatedJobPositionDto>();

            CreateMap<JobPositionDetailsDto,JobPositionViewModel>();
        }
    }
}
