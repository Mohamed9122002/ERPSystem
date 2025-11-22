using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.AttendanceDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.Profiles
{
    public class AttendanceMappingProfile :Profile
    {
        public AttendanceMappingProfile()
        {
            CreateMap<CreateAttendanceDto, Attendance>();
            CreateMap<UpdateAttendanceDto, Attendance>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 
            CreateMap<Attendance, AttendanceListDto>()
                .ForMember(dest => dest.EmployeeName,
                           opt => opt.MapFrom(src => src.Employee.FullName));
            CreateMap<Attendance, AttendanceDetailsDto>()
                .ForMember(dest => dest.EmployeeName,
                           opt => opt.MapFrom(src => src.Employee.FullName));
        }
    }
}
