using ERPSystem.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Repositories.AttendanceRepo
{
    public class AttendanceRepository(ERPDbContext dbContext) : GenericRepository<Attendance, int>(dbContext), IAttendanceRepository
    {

    }
}
