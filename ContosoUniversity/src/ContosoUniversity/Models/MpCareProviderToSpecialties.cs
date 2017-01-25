using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class MpCareProviderToSpecialties
    {
        public string CareProviderToSpecialtyDescription { get; set; }
        public int CareProviderToSpecialtyKey { get; set; }
        public Guid DescriptionId { get; set; }
        public int CareProviderKey { get; set; }
        public string CareProvider { get; set; }
        public string CareProviderName { get; set; }
        public string Credentials { get; set; }
        public int SpecialtyKey { get; set; }
        public string Specialty { get; set; }
        public string SpecialtyDescription { get; set; }
        public bool IsDefinedBy3M { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
