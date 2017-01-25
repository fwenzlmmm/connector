using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LvChargeMasterDepartments
    {
        public string ChargeMasterDepartmentDescription { get; set; }
        public string ChargeMasterDepartment { get; set; }
        public int ChargeMasterDepartmentKey { get; set; }
        public Guid DescriptionId { get; set; }
        public short SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
