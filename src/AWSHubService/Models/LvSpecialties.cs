using System;
using System.Collections.Generic;

namespace AWSHubService.Models
{
    public partial class LvSpecialties
    {
        public string SpecialtyDescription { get; set; }
        public string Specialty { get; set; }
        public int SpecialtyKey { get; set; }
        public Guid DescriptionId { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
