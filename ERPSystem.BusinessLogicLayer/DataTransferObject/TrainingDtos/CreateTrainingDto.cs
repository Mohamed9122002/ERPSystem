using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.TrainingDtos
{
    public class CreateTrainingDto
    {
        [Required(ErrorMessage = "Title Is Required")]
        [MaxLength(50, ErrorMessage = "Title Must be less than 50 Characters")]
        [MinLength(5, ErrorMessage = "Title Must be More than 5 Characters")]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
    }
}
