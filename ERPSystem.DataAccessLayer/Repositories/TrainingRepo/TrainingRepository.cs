using ERPSystem.DataAccessLayer.Contexts;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Repositories.TrainingRepo
{
    public class TrainingRepository(ERPDbContext dbContext) : GenericRepository<Training, int>(dbContext), ITrainingRepository
    {
    }
}
