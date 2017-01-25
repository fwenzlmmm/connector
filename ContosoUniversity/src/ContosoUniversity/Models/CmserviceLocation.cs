using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class CmserviceLocation
    {
        public long ServiceLocationBranchId { get; set; }
        public long FacilityBranchId { get; set; }
        public string ServiceLocationId { get; set; }
        public string DisplayName { get; set; }
        public string SiteId { get; set; }
        public Guid FacilityServiceLocationTypeId { get; set; }
        public long? Ncid { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public Guid? StateId { get; set; }
        public string Zip { get; set; }
        public int Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
