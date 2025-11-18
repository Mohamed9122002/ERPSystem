using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.DepartmentDtos
{
    public class UpdatedDepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly? CreateOn { get; set; }
    }
}
