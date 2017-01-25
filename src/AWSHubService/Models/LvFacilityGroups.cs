using System;
using System.Collections.Generic;

namespace AWSHubService.Models
{
    public partial class LvFacilityGroups
    {
        public string FacilityGroupDescription { get; set; }
        public string FacilityGroup { get; set; }
        public int FacilityGroupKey { get; set; }
        public Guid DescriptionId { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
