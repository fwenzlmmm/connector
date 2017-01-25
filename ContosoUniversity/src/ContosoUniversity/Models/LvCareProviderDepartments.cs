using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LvCareProviderDepartments
    {
        public string CareProviderDepartmentDescription { get; set; }
        public string CareProviderDepartment { get; set; }
        public int CareProviderDepartmentKey { get; set; }
        public Guid DescriptionId { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
