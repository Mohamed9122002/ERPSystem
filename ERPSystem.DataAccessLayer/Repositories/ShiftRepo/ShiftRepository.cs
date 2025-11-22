using ERPSystem.DataAccessLayer.Contexts;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Repositories.ShiftRepo
{
    public class ShiftRepository(ERPDbContext dbContext) : GenericRepository<Shift, int>(dbContext), IShiftRepository
    {
    }
}
