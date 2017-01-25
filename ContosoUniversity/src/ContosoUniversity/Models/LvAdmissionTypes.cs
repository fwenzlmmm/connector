using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LvAdmissionTypes
    {
        public string AdmissionTypeDescription { get; set; }
        public string AdmissionType { get; set; }
        public int AdmissionTypeKey { get; set; }
        public Guid DescriptionId { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
