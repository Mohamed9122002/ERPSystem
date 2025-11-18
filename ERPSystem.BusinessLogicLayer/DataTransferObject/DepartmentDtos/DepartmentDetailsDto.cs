using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.DepartmentDtos
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ManagerName { get; set; }
        public DateOnly? DateOfCreation { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        public DateOnly? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
