using System;
using System.Collections.Generic;

namespace AWSHubService.Models
{
    public partial class LvVisitTypes
    {
        public string VisitTypeDescription { get; set; }
        public string VisitType { get; set; }
        public int VisitTypeKey { get; set; }
        public Guid DescriptionId { get; set; }
        public int PatientClassification3Mkey { get; set; }
        public string PatientClassification3Mdescription { get; set; }
        public string PatientClassification3Mcode { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
