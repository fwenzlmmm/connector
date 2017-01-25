using System;
using System.Collections.Generic;

namespace AWSHubService.Models
{
    public partial class LvDischargeStatus
    {
        public string DischargeStatusDescription { get; set; }
        public string DischargeStatus { get; set; }
        public int DischargeStatusKey { get; set; }
        public Guid DescriptionId { get; set; }
        public int MpDischargeStatusKey { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
        public string LuDescription { get; set; }
        public string LuCode { get; set; }
    }
}
