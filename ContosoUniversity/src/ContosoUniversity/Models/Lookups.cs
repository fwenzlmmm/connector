using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class Lookups
    {
        public string LookupDescription { get; set; }
        public string Code { get; set; }
        public int LookupKey { get; set; }
        public int LookupNameKey { get; set; }
        public string LookupName { get; set; }
        public string LookupNameDescription { get; set; }
        public string Lookup { get; set; }
        public Guid DescriptionId { get; set; }
        public string Map1 { get; set; }
        public string Map2 { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? InactiveDate { get; set; }
        public int? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
