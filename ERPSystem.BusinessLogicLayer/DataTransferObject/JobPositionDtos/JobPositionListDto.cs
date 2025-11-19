using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.JobPositionDtos
{
    public class JobPositionListDto
    {
        public int Id { get; set; }              
        public string Title { get; set; } = null!;
        public string? Description { get; set; }   
        public int DepartmentId { get; set; }  
        public string? DepartmentName { get; set; }
    }
}
