using ERPSystem.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Repositories.PayrollItemTypeRepo
{
    public class PayrollItemTypeRepository(ERPDbContext dbContext) : GenericRepository<PayrollItemType, int>(dbContext), IPayrollItemTypeRepository
    {
    }
}
