using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class CmpayerMapping
    {
        public string PayerName { get; set; }
        public string Payer { get; set; }
        public int PayerKey { get; set; }
        public int? PayerKey360 { get; set; }
        public string PayerIdentificationNumber { get; set; }
        public Guid DescriptionId { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool? IsShow { get; set; }
        public DateTime DateCreated { get; set; }
        public bool? IsMedicarePpspaidCurrent { get; set; }
        public bool? IsMedicarePpspaidPrevious { get; set; }
        public string PreviousPayerName { get; set; }
    }
}
