using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LvAdmissionDischargeServices
    {
        public string AdmissionDischargeServiceDescription { get; set; }
        public string AdmissionDischargeService { get; set; }
        public int AdmissionDischargeServiceKey { get; set; }
        public Guid DescriptionId { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
