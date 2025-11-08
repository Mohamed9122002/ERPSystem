using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string NationalID { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime HireDate { get; set; }
        public string Status { get; set; } = "Active";
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
        public ICollection<PaySlip> Payslips { get; set; } = new List<PaySlip>();

        public ICollection<Allowance> Allowances { get; set; } = new List<Allowance>();
        public ICollection<Deduction> Deductions { get; set; } = new List<Deduction>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
        public ICollection<PerformanceReview> PerformanceReviews { get; set; } = new List<PerformanceReview>();
        public ICollection<EmployeeTraining> EmployeeTrainings { get; set; } = new List<EmployeeTraining>();
    }
}
