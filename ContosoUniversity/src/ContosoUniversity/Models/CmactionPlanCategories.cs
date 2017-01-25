using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class CmactionPlanCategories
    {
        public Guid ActionPlanCategoryId { get; set; }
        public string ActionPlanCategoryDescription { get; set; }
        public int Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
