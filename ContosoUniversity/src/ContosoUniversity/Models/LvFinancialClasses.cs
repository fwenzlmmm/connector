using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class LvFinancialClasses
    {
        public string FinancialClassDescription { get; set; }
        public string FinancialClass { get; set; }
        public int FinancialClassKey { get; set; }
        public Guid DescriptionId { get; set; }
        public int? CodefinderPayerNumber { get; set; }
        public string GrouperDescription { get; set; }
        public string GrouperClassification { get; set; }
        public string GrouperFamily { get; set; }
        public string AvailableSecondary { get; set; }
        public string HasReimbursement { get; set; }
        public int DateBasisKey { get; set; }
        public string DateBasisCode { get; set; }
        public string DateBasisDescription { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
