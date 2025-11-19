using ERPSystem.DataAccessLayer.Modules.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.JobPositionDtos
{
    public class CreatedJobPositionDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int DepartmentId { get; set; }
    }   
}
