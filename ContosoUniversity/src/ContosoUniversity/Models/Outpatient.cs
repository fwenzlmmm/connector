using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public class Outpatient
    {
        public int ID { get; set; }
        public string FinalOrWorking { get; set; }
        public DateTime DischargeDateFrom { get; set; }
        public DateTime DischargeDateTo { get; set; }

        public ICollection<vwOutpatient> Outpatients { get; set; }
    }
}
