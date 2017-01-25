using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LvChargeMasterCodeHcpcss
    {
        public string ChargeMasterCode { get; set; }
        public string ProcedureHcpcscode { get; set; }
        public int ChargeMasterCodeHcpcskey { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
