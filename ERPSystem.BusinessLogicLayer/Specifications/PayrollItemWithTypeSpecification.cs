using ERPSystem.DataAccessLayer.Modules;
using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.Specifications
{
    public class PayrollItemWithTypeSpecification :BaseSpecification<PayrollItem,int>
    {
        public PayrollItemWithTypeSpecification():base(null)
        {
            AddInclude(p => p.PayrollItemType);

        }
    }
}
