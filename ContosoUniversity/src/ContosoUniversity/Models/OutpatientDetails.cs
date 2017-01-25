using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class OutpatientDetails
    {
        public int[] IDs { get; set; }

        public ICollection<vwOutpatientDetails> OutpatientsDetails { get; set; }
    }
}
