using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class ActionPlansStatus
    {
        public Guid ActionPlansStatusId { get; set; }
        public Guid? AppId { get; set; }
        public string ActionPlansStatusDescription { get; set; }
        public int Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }
        public int Identity { get; set; }
    }
}
