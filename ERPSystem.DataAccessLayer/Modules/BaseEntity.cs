using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccessLayer.Modules
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public int LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
