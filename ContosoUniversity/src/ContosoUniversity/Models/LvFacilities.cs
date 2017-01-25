using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LvFacilities
    {
        public string FacilityName { get; set; }
        public string FacilityId { get; set; }
        public int FacilityKey { get; set; }
        public string FacilityAbbreviation { get; set; }
        public string ProviderNumber { get; set; }
        public string NationalProviderNumber { get; set; }
        public int FacilityGroupKey { get; set; }
        public string FacilityGroup { get; set; }
        public string FacilityGroupDescription { get; set; }
        public int EnterpriseKey { get; set; }
        public string EnterpriseId { get; set; }
        public string EnterpriseName { get; set; }
        public string EnterpriseAbbreviation { get; set; }
        public int? PatientIdentity { get; set; }
        public int? VisitIdentity { get; set; }
        public int CodefinderSystem { get; set; }
        public short? SortOrder { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
