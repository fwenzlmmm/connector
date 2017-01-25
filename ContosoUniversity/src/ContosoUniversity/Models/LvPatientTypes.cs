using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LvPatientTypes
    {
        public string PatientTypeDescription { get; set; }
        public string PatientType { get; set; }
        public int PatientTypeKey { get; set; }
        public Guid DescriptionId { get; set; }
        public int CodefinderSystem { get; set; }
        public int PatientClassification3Mkey { get; set; }
        public string PatientClassification3Mcode { get; set; }
        public string PatientClassification3Mdescription { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
