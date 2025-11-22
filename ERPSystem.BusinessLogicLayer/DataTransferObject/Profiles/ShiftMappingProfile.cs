using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.ShiftDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.Profiles
{
    public class ShiftMappingProfile :Profile
    {
        public ShiftMappingProfile() {
            CreateMap<Shift, ShiftDto>();
            CreateMap<CreateShiftDto, Shift>();
            CreateMap<UpdateShiftDto, Shift>();
        }
    }
}
