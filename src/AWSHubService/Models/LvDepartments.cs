using System;
using System.Collections.Generic;

namespace AWSHubService.Models
{
    public partial class LvDepartments
    {
        public string Department { get; set; }
        public int DepartmentKey { get; set; }
        public Guid DescriptionId { get; set; }
        public string DepartmentDescription { get; set; }
        public short SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
