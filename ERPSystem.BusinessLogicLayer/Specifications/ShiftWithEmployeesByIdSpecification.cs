using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Specifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.Specifications
{
    public class ShiftWithEmployeesByIdSpecification : BaseSpecification<Shift, int>
    {
        public ShiftWithEmployeesByIdSpecification(int shiftId) : base(s => s.Id == shiftId)
        {
            AddInclude(S => S.Employees);
        }
        public ShiftWithEmployeesByIdSpecification() :base(null)
        {
            AddInclude(S => S.Employees);
        }
    }
}
