using System;
using System.Collections.Generic;

namespace AWSHubService.Models
{
    public partial class LvCareProviders
    {
        public string CareProviderFullName { get; set; }
        public string CareProviderLastName { get; set; }
        public string CareProviderFirstName { get; set; }
        public string CareProviderMiddleName { get; set; }
        public string CareProvider { get; set; }
        public int CareProviderKey { get; set; }
        public string Credentials { get; set; }
        public string UniqueCareProviderIdentifierNumber { get; set; }
        public string NationalProviderIdentifier { get; set; }
        public string CareProviderIdline1 { get; set; }
        public string CareProviderIdline2 { get; set; }
        public string ProviderNumber { get; set; }
        public string ProviderRepresentative { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int StateKey { get; set; }
        public string State { get; set; }
        public string StateName { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string OtherNumber { get; set; }
        public string Email { get; set; }
        public string OtherTypeCode { get; set; }
        public int CareProviderDepartmentKey { get; set; }
        public string CareProviderDepartment { get; set; }
        public string CareProviderDepartmentDescription { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
