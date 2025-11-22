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
        public AttendanceWithEmployeeSpecification(int id) : base(A => A.Id == id)
        {
            AddInclude(A => A.Employee);
        }
    }
}
