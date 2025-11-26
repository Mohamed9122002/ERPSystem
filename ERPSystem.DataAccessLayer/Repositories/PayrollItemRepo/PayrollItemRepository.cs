using ERPSystem.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Repositories.PayrollItemRepo
{
    public class PayrollItemRepository(ERPDbContext dbContext) : GenericRepository<PayrollItem, int>(dbContext), IPayrollItemRepository
    {
    }
}
