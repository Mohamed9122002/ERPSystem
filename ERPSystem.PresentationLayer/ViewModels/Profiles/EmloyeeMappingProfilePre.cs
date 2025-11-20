using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;

namespace ERPSystem.PresentationLayer.ViewModels.Profiles
{
    public class EmloyeeMappingProfilePre :Profile
    {
        public EmloyeeMappingProfilePre()
        {
            CreateMap<EmployeeDetailsDto, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, UpdatedEmployeeDto>();
            CreateMap<EmployeeViewModel, CreatedEmployeeDto>();
        }
    }
}
