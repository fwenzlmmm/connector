using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class CsRevenueCodes
    {
        public string RevenueCodeDescription { get; set; }
        public string RevenueCode { get; set; }
        public int RevenueCodeKey { get; set; }
        public Guid DescriptionId { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
