using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class Training :BaseEntity<int>
    {       
        public string Title { get; set; } = null!;       
        public string? Description { get; set; }       
        public DateTime StartDate { get; set; }         
        public DateTime EndDate { get; set; }          
        public string? Location { get; set; }        
        public HashSet<EmployeeTraining> EmployeeTrainings { get; } = new();
    }
}
