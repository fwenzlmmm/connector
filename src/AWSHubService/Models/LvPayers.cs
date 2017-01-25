using System;
using System.Collections.Generic;

namespace AWSHubService.Models
{
    public partial class LvPayers
    {
        public string PayerName { get; set; }
        public string Payer { get; set; }
        public int PayerKey { get; set; }
        public string PayerIdentificationNumber { get; set; }
        public Guid DescriptionId { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
