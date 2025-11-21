using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.TrainingDtos
{
    public class AssignEmployeeToTrainingDto
    {
        public int TrainingId { get; set; }
        public List<int> EmployeeIds { get; set; } = new();
    }
}
