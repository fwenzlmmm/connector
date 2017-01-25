using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LvEnterprises
    {
        public string EnterpriseName { get; set; }
        public string EnterpriseId { get; set; }
        public int EnterpriseKey { get; set; }
        public string EnterpriseAbbreviation { get; set; }
        public Guid DescriptionId { get; set; }
        public short? SortOrder { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
