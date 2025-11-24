using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class Employee : BaseEntity<int>
    {
        public string FullName { get; set; } = null!;
        public string NationalID { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public decimal Salary { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public ContractType EmployeeType { get; set; }
        public DateTime HireDate { get; set; }
        public string Status { get; set; } = "Active";
        public string? Address { get; set; }
        // Fk
        public int DepartmentId { get; set; }
        // Navigation Property = > Many-to-One
        public Department Department { get; set; } = null!;
        // Fk
        public int JobPositionId { get; set; }
        // Navigation Property = > Many-to-One
        public JobPosition JobPosition { get; set; } = null!;
        // Fk 
        public int? ShiftId { get; set; }
        // Navigation Property 
        public Shift? Shift { get; set; }
        public Contract? Contract { get; set; }
        public HashSet<PaySlip> Payslips { get; set; } = new();

        public HashSet<PayrollItem> PayrollItems { get; set; } = new();
        public HashSet<Attendance> Attendances { get; set; } = new();
        public HashSet<LeaveRequest> LeaveRequests { get; set; } = new();
        public HashSet<PerformanceReview> PerformanceReviews { get; set; } = new();
        public HashSet<EmployeeTraining> EmployeeTrainings { get; set; } = new();
    }
}
