using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class MpDischargeStatusToGrouperDischargeStatus
    {
        public int DischargeStatusToGrouperDischargeStatusKey { get; set; }
        public int DischargeStatusKey { get; set; }
        public string DischargeStatus { get; set; }
        public string DischargeStatusDescription { get; set; }
        public bool LdsIsDefinedBy3M { get; set; }
        public bool LdsIsShow { get; set; }
        public int GrouperDischargeStatusKey { get; set; }
        public short GrouperKey { get; set; }
        public string GrouperDischargeStatus { get; set; }
        public string GrouperDischargeStatusDescription { get; set; }
        public bool CgdsIsDefinedBy3M { get; set; }
        public bool CgdsIsShow { get; set; }
        public bool CgdsIsExpired { get; set; }
        public short GrouperTypeKey { get; set; }
        public short GrouperVersion { get; set; }
        public string GrouperDescription { get; set; }
        public bool CgIsDefinedBy3M { get; set; }
        public bool CgIsShow { get; set; }
        public short VersionRange { get; set; }
        public short GrouperType { get; set; }
        public string GrouperTypeDescription { get; set; }
        public bool CgtIsDefinedBy3M { get; set; }
        public bool CgtIsShow { get; set; }
        public int BaseCodefinderPayerNumber { get; set; }
        public int BaseGrouperTypeKey { get; set; }
        public string BaseGrouperTypeCode { get; set; }
        public string BaseGrouperTypeDescription { get; set; }
        public int DateBasisKey { get; set; }
        public string DateBasisCode { get; set; }
        public string DateBasisDescription { get; set; }
        public int OcegrouperEditorKey { get; set; }
        public string OcegrouperEditorCode { get; set; }
        public string OcegrouperEditorDescription { get; set; }
        public int ApcgrouperKey { get; set; }
        public string ApcgrouperCode { get; set; }
        public string ApcgrouperDescription { get; set; }
        public int Key { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
