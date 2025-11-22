using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.AttendanceDtos;
using ERPSystem.PresentationLayer.ViewModels.Attendance;

namespace ERPSystem.PresentationLayer.ViewModels.Profiles
{
    public class AttendanceProfilePre:Profile
    {
        public AttendanceProfilePre()
        {
            CreateMap<AttendanceViewModel, CreateAttendanceDto>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.CheckIn, opt => opt.MapFrom(src => src.CheckIn));
            CreateMap<AttendanceDetailsDto, AttendanceViewModel>();
            CreateMap<AttendanceViewModel, UpdateAttendanceDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.CheckIn, opt => opt.MapFrom(src => src.CheckIn))
                .ForMember(dest => dest.CheckOut, opt => opt.MapFrom(src => src.CheckOut))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

        }
    }
}
