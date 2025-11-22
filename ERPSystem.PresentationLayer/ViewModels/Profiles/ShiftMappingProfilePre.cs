using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.ShiftDtos;

namespace ERPSystem.PresentationLayer.ViewModels.Profiles
{
    public class ShiftMappingProfilePre : Profile
    {
        public ShiftMappingProfilePre()
        {
            CreateMap<ShiftViewModel, CreateShiftDto>();
            CreateMap<ShiftViewModel, UpdateShiftDto>();
            CreateMap<ShiftDto, ShiftViewModel>();
        }
    }
}
