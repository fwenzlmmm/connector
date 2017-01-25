using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class CsCodefinderPayers
    {
        public string GrouperDescription { get; set; }
        public short CodefinderPayerKey { get; set; }
        public Guid DescriptionId { get; set; }
        public int CodefinderPayerNumber { get; set; }
        public string GrouperDescriptionCfpn { get; set; }
        public string GrouperClassification { get; set; }
        public string GrouperFamily { get; set; }
        public string AvailableSecondary { get; set; }
        public string HasReimbursement { get; set; }
        public int DateBasisKey { get; set; }
        public string DateBasisCode { get; set; }
        public string DateBasisDescription { get; set; }
        public short GrouperVersion { get; set; }
        public DateTime StartDate { get; set; }
        public short GrouperKey { get; set; }
        public string GrouperCode { get; set; }
        public string GrouperDescriptionLu { get; set; }
        public int CodeVersion { get; set; }
        public int IcdcodeHeaderKey { get; set; }
        public int Icdcode { get; set; }
        public int IcdcodeVersion { get; set; }
        public string IcdcodeHeaderDescription { get; set; }
        public DateTime IcdstartDate { get; set; }
        public DateTime IcdendDate { get; set; }
        public DateTime IcdmappingDate { get; set; }
        public int IcdcodeKey { get; set; }
        public int ReimbursementFormula { get; set; }
        public int? Base { get; set; }
        public int? BaseRevision { get; set; }
        public string Comment { get; set; }
        public int? Cptversion { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
