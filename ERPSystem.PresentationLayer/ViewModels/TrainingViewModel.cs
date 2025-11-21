using ERPSystem.BusinessLogicLayer.DataTransferObject.TrainingDtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ERPSystem.PresentationLayer.ViewModels
{
    public class TrainingViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string? Location { get; set; }
        public List<AssignedEmployeeDto> Employees { get; set; } = new();
        /// <summary>
        /// Employee Ids selected for the training
        /// </summary>
        public List<int> SelectedEmployeeIds { get; set; } = new();
    }
}
