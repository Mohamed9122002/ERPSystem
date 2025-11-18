using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.DepartmentDtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }           
        public string Name { get; set; } = null!;  
        public string? ManagerName { get; set; }
        public DateOnly? DateOfCreation { get; set; }
    }
}
