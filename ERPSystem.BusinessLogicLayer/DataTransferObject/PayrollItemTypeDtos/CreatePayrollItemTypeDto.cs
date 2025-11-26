using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemTypeDtos
{
    public class CreatePayrollItemTypeDto
    {
        public string Name { get; set; } = null!;
        public PayrollItemKind Kind { get; set; }
        public bool IsPercentage { get; set; }
        public decimal? Percentage { get; set; }
        public decimal? FixedAmount { get; set; }
        public bool IsTaxRelated { get; set; }
    }
}
