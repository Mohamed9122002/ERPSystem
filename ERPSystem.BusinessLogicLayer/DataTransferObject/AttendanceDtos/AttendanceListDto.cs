using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.AttendanceDtos
{
    public class AttendanceListDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = null!;
        public DateTime Date { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public AttendanceStatus Status { get; set; }
        public decimal LateHours { get; set; }
        public decimal OvertimeHours { get; set; }
        public decimal WorkingHours { get; set; }
    }
}
