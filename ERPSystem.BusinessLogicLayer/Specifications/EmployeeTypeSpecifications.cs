using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.Specifications
{
    public class EmployeeTypeSpecifications : BaseSpecification<Employee, int>
    {
        public  EmployeeTypeSpecifications(string? nationalID) : base(e => string.IsNullOrEmpty(nationalID) || e.NationalID == nationalID)
        {
            AddInclude(E => E.Department);
            AddInclude(E => E.JobPosition);
            AddInclude(E => E.Shift);
        }
        public EmployeeTypeSpecifications(int id) : base(E => E.Id == id)
        {
            AddInclude(E => E.Department);
            AddInclude(E => E.JobPosition);
            AddInclude(E => E.Shift);
        }
    }
}
