using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LvCareProviderTypes
    {
        public string CareProviderTypeDescription { get; set; }
        public string CareProviderType { get; set; }
        public int CareProviderTypeKey { get; set; }
        public Guid DescriptionId { get; set; }
        public short SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
