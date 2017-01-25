using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LookupNames
    {
        public string LookupNameDescription { get; set; }
        public string LookupName { get; set; }
        public int LookupNameKey { get; set; }
        public Guid DescriptionId { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
