﻿using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LuDischargeStatus
    {
        public string DischargeStatusDescription { get; set; }
        public string DischargeStatus { get; set; }
        public int DischargeStatusKey { get; set; }
        public Guid DescriptionId { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}