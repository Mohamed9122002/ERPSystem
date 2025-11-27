using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.Specifications
{
    public class AttendanceWithEmployeeSpecification :BaseSpecification<Attendance,int>
    {
        public AttendanceWithEmployeeSpecification():base(null)
        {
            AddInclude(A => A.Employee);
        }
        public AttendanceWithEmployeeSpecification(int employeeId , DateTime month):base(a=>a.EmployeeId == employeeId && a.Date.Month == month.Month)
        {
            AddInclude(A => A.Employee);
        }
        public AttendanceWithEmployeeSpecification(int id) : base(A => A.Id == id)
        {
            AddInclude(A => A.Employee);
        }
        
    }
}
