using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.DepartmentDtos
{
    public class CreatedDepartmentDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public DateOnly? DateOfCreation { get; set; }
    }
}
