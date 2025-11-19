using ERPSystem.DataAccessLayer.Contexts;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Repositories.JobPositionRep
{
    public class JobPositionRepository(ERPDbContext _dbContext) : GenericRepository<JobPosition,int>(_dbContext), IJobPositionRepository
    {
    }
}
