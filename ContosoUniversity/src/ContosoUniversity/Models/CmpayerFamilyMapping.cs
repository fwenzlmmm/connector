using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class CmpayerFamilyMapping
    {
        public Guid PayerMappingId { get; set; }
        public Guid PayerFamilyId { get; set; }
        public string PayerId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
