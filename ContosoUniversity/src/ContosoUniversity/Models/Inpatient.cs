using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Inpatient
    {
        public int ID { get; set; }
        public string FinalOrWorking { get; set; }
        public DateTime DischargeDateFrom { get; set; }
        public DateTime DischargeDateTo { get; set; }

        public ICollection<vwInpatient> Inpatients { get; set; }
    }
}
