using ERPSystem.DataAccessLayer.Modules.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.JobPositionDtos
{
    public class JobPositionDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public DateOnly? DateOfCreation { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        public DateOnly? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
