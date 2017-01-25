using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class MappingSavedData
    {
        public int MappingSavedDataId { get; set; }
        public string ClientValue { get; set; }
        public string ClientDescription { get; set; }
        public int MappingTableDetailsId { get; set; }
        public bool IsActive { get; set; }
        public int? MappingDataSourceId { get; set; }
    }
}
