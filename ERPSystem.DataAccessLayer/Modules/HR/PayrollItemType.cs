using ERPSystem.DataAccessLayer.Modules.HR.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules.HR
{
    public class PayrollItemType : BaseEntity<int>
    {
        public string Name { get; set; } = null!;
        public PayrollItemKind Kind { get; set; }
        public bool IsPercentage { get; set; }
        public decimal? Percentage { get; set; }
        public decimal? FixedAmount { get; set; }

        public bool IsTaxRelated { get; set; }

        public HashSet<PayrollItem> PayrollItems { get; set; } = new();
    }
}

