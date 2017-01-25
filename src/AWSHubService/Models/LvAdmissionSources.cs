using System;
using System.Collections.Generic;

namespace AWSHubService.Models
{
    public partial class LvAdmissionSources
    {
        public string AdmissionSourceDescription { get; set; }
        public string AdmissionSource { get; set; }
        public int AdmissionSourceKey { get; set; }
        public Guid DescriptionId { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
