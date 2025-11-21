using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.Specifications
{
    public class TrainingTypeSpecifications :BaseSpecification<Training, int>
    {
        public TrainingTypeSpecifications() :base(null)
        {
            AddInclude(q => q.Include(t => t.EmployeeTrainings)
                            .ThenInclude(et => et.Employee));
        }
        public TrainingTypeSpecifications(int id ) :base(t => t.Id == id) {
            AddInclude(q => q.Include(t => t.EmployeeTrainings)
                            .ThenInclude(et => et.Employee));
        }
    }
}
