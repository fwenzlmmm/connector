using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class Cmfacility
    {
        public long FacilityBranchId { get; set; }
        public long? FacilityAssociationBranchId { get; set; }
        public long? FacilitySystemBranchId { get; set; }
        public string Ncid { get; set; }
        public string Npi { get; set; }
        public string Mpn { get; set; }
        public string _360facilityId { get; set; }
        public string _837facilityKey { get; set; }
        public string SiteId { get; set; }
        public string DisplayName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public Guid? StateId { get; set; }
        public string Zip { get; set; }
        public int HasServiceLocation { get; set; }
        public int Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
