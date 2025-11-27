using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System.ComponentModel.DataAnnotations;

namespace ERPSystem.PresentationLayer.ViewModels.Payroll_temType
{
    public class PayrollItemTypeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be at most 100 characters")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Kind is required")]
        public PayrollItemKind Kind { get; set; }
        [Display(Name = "Is Percentage?")]
        public bool IsPercentage { get; set; }

        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100")]
        [Display(Name = "Percentage (%)")]
        public decimal? Percentage { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Fixed amount must be a positive number")]
        [Display(Name = "Fixed Amount")]
        public decimal? FixedAmount { get; set; }
        [Display(Name = "Is Tax Related?")]
        public bool IsTaxRelated { get; set; }
    }
}
