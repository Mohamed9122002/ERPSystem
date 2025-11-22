using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Repositories.AttendanceRepo
{
    public interface IAttendanceRepository :IGenericRepository<Attendance, int>
    {

    }
}
