using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class CmfacilitySystem
    {
        public long FacilitySystemBranchId { get; set; }
        public long? FacilityAssociationBranchId { get; set; }
        public string SiteId { get; set; }
        public string DisplayName { get; set; }
        public string Comments { get; set; }
        public int Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
