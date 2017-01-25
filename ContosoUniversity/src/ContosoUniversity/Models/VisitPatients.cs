using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class VisitPatients
    {
        public long VisitPatientKey { get; set; }
        public long PatientKey { get; set; }
        public int? EnterprisePatientKey { get; set; }
        public int? EnterpriseKey { get; set; }
        public string EnterprisePatientNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public short? BirthWeightInGrams { get; set; }
        public int? RaceKey { get; set; }
        public string RaceCode { get; set; }
        public string RaceDescription { get; set; }
        public int? EthnicityKey { get; set; }
        public string EthnicityCode { get; set; }
        public string EthnicityDescription { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string EnterpriseId { get; set; }
        public string EnterpriseName { get; set; }
        public string EnterpriseAbbreviation { get; set; }
        public string PatientMrn { get; set; }
        public int FacilityKey { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAbbreviation { get; set; }
        public string FacilityProviderNumber { get; set; }
        public string FacilityNpn { get; set; }
        public int VisitTypeKey { get; set; }
        public string VisitType { get; set; }
        public string VisitTypeDescription { get; set; }
        public int? PatientClassification3Mkey { get; set; }
        public string PcCode { get; set; }
        public string PcDescription { get; set; }
        public long VisitKey { get; set; }
        public string MedicalRecordNumber { get; set; }
        public string PatientNameId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientMiddleName { get; set; }
        public string PatientLastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int StateKey { get; set; }
        public string StateCode { get; set; }
        public string StateDescription { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string FederalTaxNumber1 { get; set; }
        public string FederalTaxNumber2 { get; set; }
        public short? AgeInYears { get; set; }
        public int? AgeInDays { get; set; }
        public int? AgeInDaysAtDischargeDate { get; set; }
        public int AgeCategoryKey { get; set; }
        public string AgeCategory { get; set; }
        public string AgeCategoryDescription { get; set; }
        public string YearOrDay { get; set; }
        public short? MinimumValue { get; set; }
        public short? MaximumValue { get; set; }
        public int SexKey { get; set; }
        public string SexCode { get; set; }
        public string SexDescription { get; set; }
        public int MaritalStatusKey { get; set; }
        public string MaritalStatusCode { get; set; }
        public string MaritalStatusDescription { get; set; }
        public int AgeSplitKey { get; set; }
        public string AgeSplit { get; set; }
        public string AgeSplitDescription { get; set; }
        public short? AsMinimumValue { get; set; }
        public short? AsMaximumValue { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
