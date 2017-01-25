using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class vwOutpatientDetails
    {
        public string EnterpriseName { get; set; }
        public string EnterpriseID { get; set; }
        public string ExportQueueKey { get; set; }
        public string EventTypeKey { get; set; }
        public string RecordType { get; set; }
        public string CodeSetKey { get; set; }
        public string VisitKey { get; set; }
        public string FacilityName { get; set; }
        public string CareProviderFullName { get; set; }
        public string PatientId { get; set; }
        public string ClaimID { get; set; }
        public string ItemLineNumber { get; set; }
        public string ItemRevenueCode { get; set; }
        public string ItemProcedure { get; set; }
        public string ItemModifier1 { get; set; }
        public string ItemModifier2 { get; set; }
        public string ItemModifier3 { get; set; }
        public string ItemModifier4 { get; set; }
        public string ItemModifier5 { get; set; }
        public string ItemServiceDate { get; set; }
        public string ItemUnitsOfService { get; set; }
        public string ItemCharges { get; set; }
        public string ItemNonCoveredCharges { get; set; }
        public string ItemPaymentApc { get; set; }
        public string ItemAPCVersion { get; set; }
    }
}
