using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.AttendanceDtos
{
    public class AttendanceDetailsDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = null!;
        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public AttendanceStatus Status { get; set; }
    }
}
