using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.TrainingDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.Profiles
{
    public class TrainingMappingProfile : Profile
    {
        public TrainingMappingProfile()
        {
            CreateMap<Training, TrainingListDto>();
            CreateMap<CreateTrainingDto, Training>();
            CreateMap<Training, TrainingDetailsDto>()
                .ForMember(dest => dest.Employees, opt =>
                opt.MapFrom(src => src.EmployeeTrainings.Select(et => new AssignedEmployeeDto
                {
                    EmployeeId = et.EmployeeId,
                    EmployeeName = et.Employee.FullName
                })));
            CreateMap<UpdateTrainingDto, Training>();
        }

    }
}
