using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.ShiftDtos
{
    public class ShiftDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ShiftType ShiftType { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int BreakMinutes { get; set; }
        public bool IsOvernight { get; set; }
        public int EmployeesCount { get; set; }

    }
}
