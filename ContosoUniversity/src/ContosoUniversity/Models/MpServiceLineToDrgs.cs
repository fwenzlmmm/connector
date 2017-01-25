using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class MpServiceLineToDrgs
    {
        public int ServiceLineUseKey { get; set; }
        public string LsluServiceLineUseDescription { get; set; }
        public short LslugpGrouperTypeKey { get; set; }
        public string LslugptGrouperTypeDescription { get; set; }
        public short LslugptGrouperType { get; set; }
        public short LslugpGrouperVersion { get; set; }
        public string LslugpGrouperDescription { get; set; }
        public string LslServiceLineDescription { get; set; }
        public string LslServiceLine { get; set; }
        public int ServiceLineKey { get; set; }
        public int ServiceLineToDrgkey { get; set; }
        public Guid DescriptionId { get; set; }
        public string ServiceLineToDrgdescription { get; set; }
        public short GrouperKey { get; set; }
        public string Drg { get; set; }
        public string CdDrgdescription { get; set; }
        public string CdDrglongDescription { get; set; }
        public string CdDrgshortDescription { get; set; }
        public int CdDrgtypeKey { get; set; }
        public string CdgGrouperDescription { get; set; }
        public short CdgGrouperVersion { get; set; }
        public short CdgGrouperTypeKey { get; set; }
        public string CdgtGrouperTypeDescription { get; set; }
        public short CdgtGrouperType { get; set; }
        public string LuLookupDescription { get; set; }
        public string LuCode { get; set; }
        public string LuLookup { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
