using AWSHubService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSHubService.Data
{
    public class ClientDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=10.104.94.93;Initial Catalog=ClientDB_237006;uid=HSA_DBUSER;pwd=password963.;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LvAdmissionDischargeServices>(entity =>
            {
                entity.HasKey(e => e.AdmissionDischargeServiceKey)
                    .HasName("PK_LvAdmissionDischargeServices");

                entity.Property(e => e.AdmissionDischargeServiceKey).ValueGeneratedNever();

                entity.Property(e => e.AdmissionDischargeService)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.AdmissionDischargeServiceDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");
            });

            modelBuilder.Entity<LvAdmissionSources>(entity =>
            {
                entity.HasKey(e => e.AdmissionSourceKey)
                    .HasName("PK_LvAdmissionSources");

                entity.Property(e => e.AdmissionSourceKey).ValueGeneratedNever();

                entity.Property(e => e.AdmissionSource)
                    .IsRequired()
                    .HasMaxLength(505);

                entity.Property(e => e.AdmissionSourceDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");
            });

            modelBuilder.Entity<LvAdmissionTypes>(entity =>
            {
                entity.HasKey(e => e.AdmissionTypeKey)
                    .HasName("PK_LvAdmissionTypes");

                entity.Property(e => e.AdmissionTypeKey).ValueGeneratedNever();

                entity.Property(e => e.AdmissionType)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.AdmissionTypeDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");
            });

            modelBuilder.Entity<LvCareProviderDepartments>(entity =>
            {
                entity.HasKey(e => e.CareProviderDepartmentKey)
                    .HasName("PK_LvCareProviderDepartments");

                entity.Property(e => e.CareProviderDepartmentKey).ValueGeneratedNever();

                entity.Property(e => e.CareProviderDepartment)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.CareProviderDepartmentDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");
            });

            modelBuilder.Entity<LvCareProviderTypes>(entity =>
            {
                entity.HasKey(e => e.CareProviderTypeKey)
                    .HasName("PK_LvCareProviderTypes");

                entity.Property(e => e.CareProviderTypeKey).ValueGeneratedNever();

                entity.Property(e => e.CareProviderType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CareProviderTypeDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");
            });

            modelBuilder.Entity<LvCareProviders>(entity =>
            {
                entity.HasKey(e => e.CareProviderKey)
                    .HasName("PK_LvCareProviders");

                entity.Property(e => e.CareProviderKey).ValueGeneratedNever();

                entity.Property(e => e.Address1).HasMaxLength(100);

                entity.Property(e => e.Address2).HasMaxLength(100);

                entity.Property(e => e.CareProvider)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.CareProviderDepartment).HasMaxLength(15);

                entity.Property(e => e.CareProviderDepartmentDescription).HasMaxLength(50);

                entity.Property(e => e.CareProviderFirstName).HasMaxLength(35);

                entity.Property(e => e.CareProviderFullName).HasMaxLength(400);

                entity.Property(e => e.CareProviderIdline1)
                    .HasColumnName("CareProviderIDLine1")
                    .HasMaxLength(25);

                entity.Property(e => e.CareProviderIdline2)
                    .HasColumnName("CareProviderIDLine2")
                    .HasMaxLength(25);

                entity.Property(e => e.CareProviderLastName).HasMaxLength(35);

                entity.Property(e => e.CareProviderMiddleName).HasMaxLength(35);

                entity.Property(e => e.CellPhoneNumber).HasMaxLength(25);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.County).HasMaxLength(50);

                entity.Property(e => e.Credentials).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(150);

                entity.Property(e => e.FaxNumber).HasMaxLength(25);

                entity.Property(e => e.NationalProviderIdentifier).HasMaxLength(35);

                entity.Property(e => e.OtherNumber).HasMaxLength(25);

                entity.Property(e => e.OtherTypeCode).HasMaxLength(10);

                entity.Property(e => e.PhoneNumber).HasMaxLength(25);

                entity.Property(e => e.ProviderNumber).HasMaxLength(25);

                entity.Property(e => e.ProviderRepresentative).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.StateName).HasMaxLength(500);

                entity.Property(e => e.UniqueCareProviderIdentifierNumber).HasMaxLength(35);

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<LvChargeMasterCodeHcpcss>(entity =>
            {
                entity.HasKey(e => e.ChargeMasterCodeHcpcskey)
                    .HasName("PK_LvChargeMasterCodeHCPCSs");

                entity.ToTable("LvChargeMasterCodeHCPCSs", "op");

                entity.Property(e => e.ChargeMasterCodeHcpcskey)
                    .HasColumnName("ChargeMasterCodeHCPCSKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChargeMasterCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ProcedureHcpcscode)
                    .IsRequired()
                    .HasColumnName("ProcedureHCPCSCode")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<LvChargeMasterDepartments>(entity =>
            {
                entity.HasKey(e => e.ChargeMasterDepartmentKey)
                    .HasName("PK_LvChargeMasterDepartments");

                entity.Property(e => e.ChargeMasterDepartmentKey).ValueGeneratedNever();

                entity.Property(e => e.ChargeMasterDepartment)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ChargeMasterDepartmentDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");
            });

            modelBuilder.Entity<LvDepartments>(entity =>
            {
                entity.HasKey(e => e.DepartmentKey)
                    .HasName("PK_LvDepartments");

                entity.Property(e => e.DepartmentKey).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DepartmentDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");
            });

            modelBuilder.Entity<LvDischargeStatus>(entity =>
            {
                entity.HasKey(e => e.DischargeStatusKey)
                    .HasName("PK_LvDischargeStatus");

                entity.Property(e => e.DischargeStatusKey).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");

                entity.Property(e => e.DischargeStatus)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.DischargeStatusDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LuCode).HasMaxLength(50);

                entity.Property(e => e.LuDescription).HasMaxLength(500);
            });

            modelBuilder.Entity<LvEnterprises>(entity =>
            {
                entity.HasKey(e => e.EnterpriseKey)
                    .HasName("PK_LvEnterprises");

                entity.Property(e => e.EnterpriseKey).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");

                entity.Property(e => e.EnterpriseAbbreviation).HasMaxLength(15);

                entity.Property(e => e.EnterpriseId)
                    .IsRequired()
                    .HasColumnName("EnterpriseID")
                    .HasMaxLength(30);

                entity.Property(e => e.EnterpriseName).HasMaxLength(150);
            });

            modelBuilder.Entity<LvFacilities>(entity =>
            {
                entity.HasKey(e => e.FacilityKey)
                    .HasName("PK_LvFacilities");

                entity.Property(e => e.FacilityKey).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.EnterpriseAbbreviation)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.EnterpriseId)
                    .IsRequired()
                    .HasColumnName("EnterpriseID")
                    .HasMaxLength(30);

                entity.Property(e => e.EnterpriseName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FacilityAbbreviation).HasMaxLength(15);

                entity.Property(e => e.FacilityGroup)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FacilityGroupDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FacilityId)
                    .IsRequired()
                    .HasColumnName("FacilityID")
                    .HasMaxLength(30);

                entity.Property(e => e.FacilityName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.NationalProviderNumber).HasMaxLength(20);

                entity.Property(e => e.ProviderNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<LvFacilityGroups>(entity =>
            {
                entity.HasKey(e => e.FacilityGroupKey)
                    .HasName("PK_LvFacilityGroups");

                entity.Property(e => e.FacilityGroupKey).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");

                entity.Property(e => e.FacilityGroup)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FacilityGroupDescription)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LvFinancialClasses>(entity =>
            {
                entity.HasKey(e => e.FinancialClassKey)
                    .HasName("PK_LvFinancialClasses");

                entity.Property(e => e.FinancialClassKey).ValueGeneratedNever();

                entity.Property(e => e.AvailableSecondary)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DateBasisCode).HasMaxLength(50);

                entity.Property(e => e.DateBasisDescription).HasMaxLength(500);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");

                entity.Property(e => e.FinancialClass)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.FinancialClassDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GrouperClassification)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.GrouperDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GrouperFamily)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.HasReimbursement)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<LvPatientTypes>(entity =>
            {
                entity.HasKey(e => e.PatientTypeKey)
                    .HasName("PK_LvPatientTypes");

                entity.Property(e => e.PatientTypeKey).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");

                entity.Property(e => e.PatientClassification3Mcode)
                    .HasColumnName("PatientClassification3MCode")
                    .HasMaxLength(50);

                entity.Property(e => e.PatientClassification3Mdescription)
                    .HasColumnName("PatientClassification3MDescription")
                    .HasMaxLength(500);

                entity.Property(e => e.PatientClassification3Mkey).HasColumnName("PatientClassification3MKey");

                entity.Property(e => e.PatientType)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.PatientTypeDescription)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LvPayers>(entity =>
            {
                entity.HasKey(e => e.PayerKey)
                    .HasName("PK_LvPayers");

                entity.Property(e => e.PayerKey).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");

                entity.Property(e => e.Payer)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PayerIdentificationNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PayerName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<LvSpecialties>(entity =>
            {
                entity.HasKey(e => e.SpecialtyKey)
                    .HasName("PK_LvSpecialties");

                entity.Property(e => e.SpecialtyKey).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");

                entity.Property(e => e.Specialty)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SpecialtyDescription)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<LvVisitTypes>(entity =>
            {
                entity.HasKey(e => e.VisitTypeKey)
                    .HasName("PK_LvVisitTypes");

                entity.Property(e => e.VisitTypeKey).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");

                entity.Property(e => e.PatientClassification3Mcode)
                    .HasColumnName("PatientClassification3MCode")
                    .HasMaxLength(50);

                entity.Property(e => e.PatientClassification3Mdescription)
                    .HasColumnName("PatientClassification3MDescription")
                    .HasMaxLength(500);

                entity.Property(e => e.PatientClassification3Mkey).HasColumnName("PatientClassification3MKey");

                entity.Property(e => e.VisitType)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.VisitTypeDescription)
                    .IsRequired()
                    .HasMaxLength(50);
            });


            modelBuilder.Entity<VisitPatients>(entity =>
            {
                entity.HasKey(e => e.VisitPatientKey)
                    .HasName("PK_VisitPatients");

                entity.Property(e => e.VisitPatientKey).ValueGeneratedNever();

                entity.Property(e => e.Address1).HasMaxLength(100);

                entity.Property(e => e.Address2).HasMaxLength(100);

                entity.Property(e => e.AgeCategory).HasMaxLength(15);

                entity.Property(e => e.AgeCategoryDescription).HasMaxLength(50);

                entity.Property(e => e.AgeSplit).HasMaxLength(15);

                entity.Property(e => e.AgeSplitDescription).HasMaxLength(50);

                entity.Property(e => e.AsMaximumValue).HasColumnName("asMaximumValue");

                entity.Property(e => e.AsMinimumValue).HasColumnName("asMinimumValue");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.County).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EnterpriseAbbreviation).HasMaxLength(15);

                entity.Property(e => e.EnterpriseId)
                    .HasColumnName("EnterpriseID")
                    .HasMaxLength(30);

                entity.Property(e => e.EnterpriseName).HasMaxLength(150);

                entity.Property(e => e.EnterprisePatientNumber).HasMaxLength(50);

                entity.Property(e => e.EthnicityCode).HasMaxLength(50);

                entity.Property(e => e.EthnicityDescription).HasMaxLength(500);

                entity.Property(e => e.FacilityAbbreviation).HasMaxLength(15);

                entity.Property(e => e.FacilityName).HasMaxLength(150);

                entity.Property(e => e.FacilityNpn)
                    .HasColumnName("FacilityNPN")
                    .HasMaxLength(200);

                entity.Property(e => e.FacilityProviderNumber).HasMaxLength(20);

                entity.Property(e => e.FaxNumber).HasMaxLength(25);

                entity.Property(e => e.FederalTaxNumber1).HasMaxLength(5);

                entity.Property(e => e.FederalTaxNumber2).HasMaxLength(10);

                entity.Property(e => e.MaritalStatusCode).HasMaxLength(50);

                entity.Property(e => e.MaritalStatusDescription).HasMaxLength(500);

                entity.Property(e => e.MedicalRecordNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PatientClassification3Mkey).HasColumnName("PatientClassification3MKey");

                entity.Property(e => e.PatientFirstName)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.PatientLastName)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.PatientMiddleName).HasMaxLength(35);

                entity.Property(e => e.PatientMrn)
                    .HasColumnName("PatientMRN")
                    .HasMaxLength(50);

                entity.Property(e => e.PatientNameId)
                    .HasColumnName("PatientNameID")
                    .HasMaxLength(50);

                entity.Property(e => e.PcCode).HasMaxLength(50);

                entity.Property(e => e.PcDescription).HasMaxLength(500);

                entity.Property(e => e.PhoneNumber).HasMaxLength(25);

                entity.Property(e => e.RaceCode).HasMaxLength(50);

                entity.Property(e => e.RaceDescription).HasMaxLength(500);

                entity.Property(e => e.SexCode).HasMaxLength(50);

                entity.Property(e => e.SexDescription).HasMaxLength(500);

                entity.Property(e => e.SocialSecurityNumber).HasMaxLength(9);

                entity.Property(e => e.StateCode).HasMaxLength(50);

                entity.Property(e => e.StateDescription).HasMaxLength(500);

                entity.Property(e => e.VisitType).HasMaxLength(15);

                entity.Property(e => e.VisitTypeDescription).HasMaxLength(50);

                entity.Property(e => e.YearOrDay).HasMaxLength(1);

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<vwInpatient>(entity =>
            {
                entity.Property(e => e.EnterpriseName).HasMaxLength(50);
                entity.Property(e => e.EnterpriseID).HasMaxLength(50);
                entity.HasKey(e => new { e.ExportQueueKey });
                entity.Property(e => e.EventTypeKey).HasMaxLength(50);
                entity.Property(e => e.RecordType).HasMaxLength(50);
                entity.Property(e => e.CodeSetKey).HasMaxLength(50);
                entity.Property(e => e.VisitKey).HasMaxLength(50);
                entity.Property(e => e.FacilityName).HasMaxLength(50);
                entity.Property(e => e.WorkingOrFinal).HasMaxLength(50);
                entity.Property(e => e.PatientClassifications3M).HasMaxLength(50);
                entity.Property(e => e.PatientType).HasMaxLength(50);
                entity.Property(e => e.PatientTypeDescription).HasMaxLength(50);
                entity.Property(e => e.VisitType).HasMaxLength(50);
                entity.Property(e => e.VisitTypeDescription).HasMaxLength(50);
                entity.Property(e => e.PatientLastName).HasMaxLength(50);
                entity.Property(e => e.PatientFirstName).HasMaxLength(50);
                entity.Property(e => e.PatientMiddleName).HasMaxLength(50);
                entity.Property(e => e.PatientAlias).HasMaxLength(50);
                entity.Property(e => e.StreetAddress1).HasMaxLength(50);
                entity.Property(e => e.StreetAddress2).HasMaxLength(50);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.State).HasMaxLength(50);
                entity.Property(e => e.ZipCode).HasMaxLength(50);
                entity.Property(e => e.County).HasMaxLength(50);
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(50);
                entity.Property(e => e.CellPhone).HasMaxLength(50);
                entity.Property(e => e.Fax).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.BirthDateTime).HasMaxLength(50);
                entity.Property(e => e.BirthWeight).HasMaxLength(50);
                entity.Property(e => e.Sex).HasMaxLength(50);
                entity.Property(e => e.MaritalStatus).HasMaxLength(50);
                entity.Property(e => e.Race).HasMaxLength(50);
                entity.Property(e => e.RaceDescription).HasMaxLength(50);
                entity.Property(e => e.Ethnicity).HasMaxLength(50);
                entity.Property(e => e.EthnicityDescription).HasMaxLength(50);
                entity.Property(e => e.SSN).HasMaxLength(50);
                entity.Property(e => e.CitizenshipStatus).HasMaxLength(50);
                entity.Property(e => e.MilitaryStatus).HasMaxLength(50);
                entity.Property(e => e.DriversLicenseNumber).HasMaxLength(50);
                entity.Property(e => e.ProviderId).HasMaxLength(50);
                entity.Property(e => e.ProviderNumber).HasMaxLength(50);
                entity.Property(e => e.PatientId).HasMaxLength(50);
                entity.Property(e => e.MRN).HasMaxLength(50);
                entity.Property(e => e.ClaimID).HasMaxLength(50);
                entity.Property(e => e.AdmitDate).HasMaxLength(50);
                entity.Property(e => e.AdmitHour).HasMaxLength(50);
                entity.Property(e => e.TypeOfAdmission).HasMaxLength(50);
                entity.Property(e => e.AdmissionTypeDescription).HasMaxLength(50);
                entity.Property(e => e.MarylandNatureOfAdmission).HasMaxLength(50);
                entity.Property(e => e.MarylandNatureOfAdmissionDescription).HasMaxLength(50);
                entity.Property(e => e.PointOfOrigin).HasMaxLength(50);
                entity.Property(e => e.AgeInDays).HasMaxLength(50);
                entity.Property(e => e.AgeInYears).HasMaxLength(50);
                entity.Property(e => e.IcdVersionQualifier).HasMaxLength(50);
                entity.Property(e => e.AdmitDiagnosis).HasMaxLength(50);
                entity.Property(e => e.PrincipalDiagnosis).HasMaxLength(50);
                entity.Property(e => e.PrincipalDiagnosisPOA).HasMaxLength(50);
                entity.Property(e => e.PrincipalProcedure).HasMaxLength(50);
                entity.Property(e => e.PrincipalProcedureDate).HasMaxLength(50);
                entity.Property(e => e.LOS).HasMaxLength(50);
                entity.Property(e => e.DischargeDate).HasMaxLength(50);
                entity.Property(e => e.DischargeHour).HasMaxLength(50);
                entity.Property(e => e.DischargeStatus).HasMaxLength(50);
                entity.Property(e => e.DischargeStatusLocal).HasMaxLength(50);
                entity.Property(e => e.PrimaryPayer).HasMaxLength(50);
                entity.Property(e => e.SecondaryPayer).HasMaxLength(50);
                entity.Property(e => e.TertiaryPayer).HasMaxLength(50);
                entity.Property(e => e.FinancialClass).HasMaxLength(50);
                entity.Property(e => e.Coder).HasMaxLength(50);
                entity.Property(e => e.Reviewer).HasMaxLength(50);
                entity.Property(e => e.NursingUnit).HasMaxLength(50);
                entity.Property(e => e.PatientRoom).HasMaxLength(50);
                entity.Property(e => e.PatientBed).HasMaxLength(50);
                entity.Property(e => e.AttendingNPI).HasMaxLength(50);
                entity.Property(e => e.AttendingName).HasMaxLength(50);
                entity.Property(e => e.AttendingDepartment).HasMaxLength(50);
                entity.Property(e => e.OperatingNPI).HasMaxLength(50);
                entity.Property(e => e.OperatingName).HasMaxLength(50);
                entity.Property(e => e.OperatingDepartment).HasMaxLength(50);
                entity.Property(e => e.OthOperatingNPI).HasMaxLength(50);
                entity.Property(e => e.OthOperatingName).HasMaxLength(50);
                entity.Property(e => e.OthOperatingDepartment).HasMaxLength(50);
                entity.Property(e => e.RenderingNPI).HasMaxLength(50);
                entity.Property(e => e.RenderingName).HasMaxLength(50);
                entity.Property(e => e.RenderingDepartment).HasMaxLength(50);
                entity.Property(e => e.GrouperType).HasMaxLength(50);
                entity.Property(e => e.GrouperVersion).HasMaxLength(50);
                entity.Property(e => e.PaymentDRG).HasMaxLength(50);
                entity.Property(e => e.PaymentSOI).HasMaxLength(50);
                entity.Property(e => e.TotalCharges).HasMaxLength(50);
                entity.Property(e => e.TotalNonCharges).HasMaxLength(50);
                entity.Property(e => e.TypeOfBill).HasMaxLength(50);
                entity.Property(e => e.PreviousDischargeDate).HasMaxLength(50);
                entity.Property(e => e.BrainInjuryReserveFlag).HasMaxLength(50);
                entity.Property(e => e.CancerReserveFlag).HasMaxLength(50);
                entity.Property(e => e.TypeOfService).HasMaxLength(50);
                entity.Property(e => e.DeathDate).HasMaxLength(50);
                entity.Property(e => e.ConditionCode1).HasMaxLength(50);
                entity.Property(e => e.ConditionCode2).HasMaxLength(50);
                entity.Property(e => e.ConditionCode3).HasMaxLength(50);
                entity.Property(e => e.ConditionCode4).HasMaxLength(50);
                entity.Property(e => e.ConditionCode5).HasMaxLength(50);
                entity.Property(e => e.ConditionCode6).HasMaxLength(50);
                entity.Property(e => e.ConditionCode7).HasMaxLength(50);
                entity.Property(e => e.ConditionCode8).HasMaxLength(50);
                entity.Property(e => e.ConditionCode9).HasMaxLength(50);
                entity.Property(e => e.ConditionCode10).HasMaxLength(50);
                entity.Property(e => e.ConditionCode11).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCode1).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCodeFromDate1).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCodeThroughDate1).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCode2).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCodeFromDate2).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCodeThroughDate2).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCode3).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCodeFromDate3).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCodeThroughDate3).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCode4).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCodeFromDate4).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCodeThroughDate4).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCode5).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCodeFromDate5).HasMaxLength(50);
                entity.Property(e => e.OccurrenceSpanCodeThroughDate5).HasMaxLength(50);
                entity.Property(e => e.ValueCode1).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount1).HasMaxLength(50);
                entity.Property(e => e.ValueCode2).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount2).HasMaxLength(50);
                entity.Property(e => e.ValueCode3).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount3).HasMaxLength(50);
                entity.Property(e => e.ValueCode4).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount4).HasMaxLength(50);
                entity.Property(e => e.ValueCode5).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount5).HasMaxLength(50);
                entity.Property(e => e.ValueCode6).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount6).HasMaxLength(50);
                entity.Property(e => e.ValueCode7).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount7).HasMaxLength(50);
                entity.Property(e => e.ValueCode8).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount8).HasMaxLength(50);
                entity.Property(e => e.ValueCode9).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount9).HasMaxLength(50);
                entity.Property(e => e.ValueCode10).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount10).HasMaxLength(50);
                entity.Property(e => e.ValueCode11).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount11).HasMaxLength(50);
                entity.Property(e => e.ValueCode12).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount12).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis1).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA1).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis2).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA2).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis3).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA3).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis4).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA4).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis5).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA5).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis6).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA6).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis7).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA7).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis8).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA8).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis9).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA9).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis10).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA10).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis11).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA11).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis12).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA12).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis13).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA13).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis14).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA14).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis15).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA15).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis16).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA16).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis17).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA17).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis18).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA18).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis19).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA19).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis20).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA20).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis21).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA21).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis22).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA22).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis23).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA23).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis24).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA24).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis25).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA25).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis26).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA26).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis27).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA27).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis28).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA28).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis29).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA29).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis30).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA30).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis31).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA31).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis32).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA32).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis33).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA33).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis34).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA34).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis35).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA35).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis36).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA36).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis37).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA37).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis38).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA38).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis39).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA39).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis40).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA40).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis41).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA41).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis42).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA42).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis43).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA43).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis44).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA44).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis45).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA45).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis46).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA46).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis47).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA47).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis48).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA48).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis49).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA49).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis50).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA50).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis51).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA51).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis52).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA52).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis53).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA53).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis54).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA54).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis55).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA55).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis56).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA56).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis57).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA57).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis58).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA58).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis59).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA59).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis60).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA60).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis61).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA61).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis62).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA62).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis63).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA63).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis64).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA64).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis65).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA65).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis66).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA66).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis67).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA67).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis68).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA68).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis69).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA69).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis70).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA70).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis71).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA71).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis72).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA72).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis73).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA73).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis74).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA74).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis75).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA75).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis76).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA76).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis77).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA77).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis78).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA78).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis79).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA79).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis80).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA80).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis81).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA81).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis82).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA82).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis83).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA83).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis84).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA84).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis85).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA85).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis86).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA86).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis87).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA87).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis88).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA88).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis89).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA89).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis90).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA90).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis91).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA91).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis92).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA92).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis93).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA93).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis94).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA94).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis95).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA95).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis96).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA96).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis97).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA97).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis98).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA98).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis99).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA99).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure1).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate1).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure2).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate2).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure3).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate3).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure4).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate4).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure5).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate5).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure6).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate6).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure7).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate7).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure8).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate8).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure9).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate9).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure10).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate10).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure11).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate11).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure12).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate12).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure13).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate13).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure14).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate14).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure15).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate15).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure16).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate16).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure17).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate17).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure18).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate18).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure19).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate19).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure20).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate20).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure21).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate21).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure22).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate22).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure23).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate23).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure24).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate24).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure25).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate25).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure26).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate26).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure27).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate27).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure28).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate28).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure29).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate29).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure30).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate30).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure31).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate31).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure32).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate32).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure33).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate33).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure34).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate34).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure35).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate35).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure36).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate36).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure37).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate37).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure38).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate38).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure39).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate39).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure40).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate40).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure41).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate41).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure42).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate42).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure43).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate43).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure44).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate44).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure45).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate45).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure46).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate46).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure47).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate47).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure48).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate48).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure49).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate49).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure50).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate50).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure51).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate51).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure52).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate52).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure53).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate53).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure54).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate54).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure55).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate55).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure56).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate56).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure57).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate57).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure58).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate58).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure59).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate59).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure60).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate60).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure61).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate61).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure62).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate62).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure63).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate63).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure64).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate64).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure65).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate65).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure66).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate66).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure67).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate67).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure68).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate68).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure69).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate69).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure70).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate70).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure71).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate71).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure72).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate72).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure73).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate73).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure74).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate74).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure75).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate75).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure76).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate76).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure77).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate77).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure78).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate78).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure79).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate79).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure80).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate80).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure81).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate81).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure82).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate82).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure83).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate83).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure84).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate84).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure85).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate85).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure86).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate86).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure87).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate87).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure88).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate88).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure89).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate89).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure90).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate90).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure91).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate91).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure92).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate92).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure93).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate93).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure94).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate94).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure95).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate95).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure96).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate96).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure97).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate97).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure98).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate98).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedure99).HasMaxLength(50);
                entity.Property(e => e.SecondaryProcedureDate99).HasMaxLength(50);
            });

            modelBuilder.Entity<vwOutpatient>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id"); ;
                entity.Property(e => e.EnterpriseName).HasMaxLength(50);
                entity.Property(e => e.EnterpriseID).HasMaxLength(50);
                entity.Property(e => e.ExportQueueKey).HasMaxLength(50);
                entity.Property(e => e.EventTypeKey).HasMaxLength(50);
                entity.Property(e => e.RecordType).HasMaxLength(50);
                entity.Property(e => e.CodeSetKey).HasMaxLength(50);
                entity.Property(e => e.VisitKey).HasMaxLength(50);
                entity.Property(e => e.FacilityName).HasMaxLength(50);
                entity.Property(e => e.WorkingOrFinal).HasMaxLength(50);
                entity.Property(e => e.PatientClassifications3M).HasMaxLength(50);
                entity.Property(e => e.PatientType).HasMaxLength(50);
                entity.Property(e => e.PatientTypeDescription).HasMaxLength(50);
                entity.Property(e => e.VisitType).HasMaxLength(50);
                entity.Property(e => e.VisitTypeDescription).HasMaxLength(50);
                entity.Property(e => e.PatientLastName).HasMaxLength(50);
                entity.Property(e => e.PatientFirstName).HasMaxLength(50);
                entity.Property(e => e.PatientMiddleName).HasMaxLength(50);
                entity.Property(e => e.PatientAlias).HasMaxLength(50);
                entity.Property(e => e.StreetAddress1).HasMaxLength(50);
                entity.Property(e => e.StreetAddress2).HasMaxLength(50);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.State).HasMaxLength(50);
                entity.Property(e => e.ZipCode).HasMaxLength(50);
                entity.Property(e => e.County).HasMaxLength(50);
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(50);
                entity.Property(e => e.CellPhone).HasMaxLength(50);
                entity.Property(e => e.Fax).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.BirthDateTime).HasMaxLength(50);
                entity.Property(e => e.Sex).HasMaxLength(50);
                entity.Property(e => e.MaritalStatus).HasMaxLength(50);
                entity.Property(e => e.Race).HasMaxLength(50);
                entity.Property(e => e.RaceDescription).HasMaxLength(50);
                entity.Property(e => e.Ethnicity).HasMaxLength(50);
                entity.Property(e => e.EthnicityDescription).HasMaxLength(50);
                entity.Property(e => e.SSN).HasMaxLength(50);
                entity.Property(e => e.CitizenshipStatus).HasMaxLength(50);
                entity.Property(e => e.MilitaryStatus).HasMaxLength(50);
                entity.Property(e => e.DriversLicenseNumber).HasMaxLength(50);
                entity.Property(e => e.ProviderId).HasMaxLength(50);
                entity.Property(e => e.ProviderNumber).HasMaxLength(50);
                entity.Property(e => e.PatientId).HasMaxLength(50);
                entity.Property(e => e.MRN).HasMaxLength(50);
                entity.Property(e => e.ClaimID).HasMaxLength(50);
                entity.Property(e => e.FromDate).HasMaxLength(50);
                entity.Property(e => e.TypeOfAdmission).HasMaxLength(50);
                entity.Property(e => e.AdmissionTypeDescription).HasMaxLength(50);
                entity.Property(e => e.AgeInDays).HasMaxLength(50);
                entity.Property(e => e.AgeInYears).HasMaxLength(50);
                entity.Property(e => e.IcdVersionQualifier).HasMaxLength(50);
                entity.Property(e => e.ReasonForVisitDiagnosis1).HasMaxLength(50);
                entity.Property(e => e.ReasonForVisitDiagnosis2).HasMaxLength(50);
                entity.Property(e => e.ReasonForVisitDiagnosis3).HasMaxLength(50);
                entity.Property(e => e.AdmitDiagnosis).HasMaxLength(50);
                entity.Property(e => e.PrincipalDiagnosis).HasMaxLength(50);
                entity.Property(e => e.PrincipalDiagnosisPOA).HasMaxLength(50);
                entity.Property(e => e.DischargeDate).HasMaxLength(50);
                entity.Property(e => e.DischargeStatus).HasMaxLength(50);
                entity.Property(e => e.DischargeStatusLocal).HasMaxLength(50);
                entity.Property(e => e.PrimaryPayer).HasMaxLength(50);
                entity.Property(e => e.SecondaryPayer).HasMaxLength(50);
                entity.Property(e => e.TertiaryPayer).HasMaxLength(50);
                entity.Property(e => e.FinancialClass).HasMaxLength(50);
                entity.Property(e => e.AttendingNPI).HasMaxLength(50);
                entity.Property(e => e.AttendingName).HasMaxLength(50);
                entity.Property(e => e.AttendingDepartment).HasMaxLength(50);
                entity.Property(e => e.OperatingNPI).HasMaxLength(50);
                entity.Property(e => e.OperatingName).HasMaxLength(50);
                entity.Property(e => e.OperatingDepartment).HasMaxLength(50);
                entity.Property(e => e.ReferringNPI).HasMaxLength(50);
                entity.Property(e => e.ReferringName).HasMaxLength(50);
                entity.Property(e => e.ReferringDepartment).HasMaxLength(50);
                entity.Property(e => e.RenderingNPI).HasMaxLength(50);
                entity.Property(e => e.RenderingName).HasMaxLength(50);
                entity.Property(e => e.RenderingDepartment).HasMaxLength(50);
                entity.Property(e => e.GrouperType).HasMaxLength(50);
                entity.Property(e => e.GrouperVersion).HasMaxLength(50);
                entity.Property(e => e.TotalCharges).HasMaxLength(50);
                entity.Property(e => e.TotalNonCharges).HasMaxLength(50);
                entity.Property(e => e.TypeOfBill).HasMaxLength(50);
                entity.Property(e => e.DeathDate).HasMaxLength(50);
                entity.Property(e => e.ConditionCode1).HasMaxLength(50);
                entity.Property(e => e.ConditionCode2).HasMaxLength(50);
                entity.Property(e => e.ConditionCode3).HasMaxLength(50);
                entity.Property(e => e.ConditionCode4).HasMaxLength(50);
                entity.Property(e => e.ConditionCode5).HasMaxLength(50);
                entity.Property(e => e.ConditionCode6).HasMaxLength(50);
                entity.Property(e => e.ConditionCode7).HasMaxLength(50);
                entity.Property(e => e.ConditionCode8).HasMaxLength(50);
                entity.Property(e => e.ConditionCode9).HasMaxLength(50);
                entity.Property(e => e.ConditionCode10).HasMaxLength(50);
                entity.Property(e => e.ConditionCode11).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCode1).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCodeDate1).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCode2).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCodeDate2).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCode3).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCodeDate3).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCode4).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCodeDate4).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCode5).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCodeDate5).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCode6).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCodeDate6).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCode7).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCodeDate7).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCode8).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCodeDate8).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCode9).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCodeDate9).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCode10).HasMaxLength(50);
                entity.Property(e => e.OccurrenceCodeDate10).HasMaxLength(50);
                entity.Property(e => e.ValueCode1).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount1).HasMaxLength(50);
                entity.Property(e => e.ValueCode2).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount2).HasMaxLength(50);
                entity.Property(e => e.ValueCode3).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount3).HasMaxLength(50);
                entity.Property(e => e.ValueCode4).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount4).HasMaxLength(50);
                entity.Property(e => e.ValueCode5).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount5).HasMaxLength(50);
                entity.Property(e => e.ValueCode6).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount6).HasMaxLength(50);
                entity.Property(e => e.ValueCode7).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount7).HasMaxLength(50);
                entity.Property(e => e.ValueCode8).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount8).HasMaxLength(50);
                entity.Property(e => e.ValueCode9).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount9).HasMaxLength(50);
                entity.Property(e => e.ValueCode10).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount10).HasMaxLength(50);
                entity.Property(e => e.ValueCode11).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount11).HasMaxLength(50);
                entity.Property(e => e.ValueCode12).HasMaxLength(50);
                entity.Property(e => e.ValueCodeAmount12).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis1).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA1).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis2).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA2).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis3).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA3).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis4).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA4).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis5).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA5).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis6).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA6).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis7).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA7).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis8).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA8).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis9).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA9).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis10).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA10).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis11).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA11).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis12).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA12).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis13).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA13).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis14).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA14).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis15).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA15).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis16).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA16).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis17).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA17).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis18).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA18).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis19).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA19).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis20).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA20).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis21).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA21).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis22).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA22).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosis23).HasMaxLength(50);
                entity.Property(e => e.SecondaryDiagnosisPOA23).HasMaxLength(50);
                entity.HasMany(e => e.OutpatientDetails);
            });

            modelBuilder.Entity<vwOutpatientDetails>(entity =>
            {
                entity.HasKey(e => e.vwOutpatientId).HasName("vwOutpatientId");
                entity.Property(e => e.EnterpriseName).HasMaxLength(50);
                entity.Property(e => e.EnterpriseID).HasMaxLength(50);
                entity.Property(e => e.ExportQueueKey).HasMaxLength(50);
                entity.Property(e => e.EventTypeKey).HasMaxLength(50);
                entity.Property(e => e.RecordType).HasMaxLength(50);
                entity.Property(e => e.CodeSetKey).HasMaxLength(50);
                entity.Property(e => e.VisitKey).HasMaxLength(50);
                entity.Property(e => e.FacilityName).HasMaxLength(50);
                entity.Property(e => e.CareProviderFullName).HasMaxLength(50);
                entity.Property(e => e.PatientId).HasMaxLength(50);
                entity.Property(e => e.ClaimID).HasMaxLength(50);
                entity.Property(e => e.ItemLineNumber).HasMaxLength(50);
                entity.Property(e => e.ItemRevenueCode).HasMaxLength(50);
                entity.Property(e => e.ItemProcedure).HasMaxLength(50);
                entity.Property(e => e.ItemModifier1).HasMaxLength(50);
                entity.Property(e => e.ItemModifier2).HasMaxLength(50);
                entity.Property(e => e.ItemModifier3).HasMaxLength(50);
                entity.Property(e => e.ItemModifier4).HasMaxLength(50);
                entity.Property(e => e.ItemModifier5).HasMaxLength(50);
                entity.Property(e => e.ItemServiceDate).HasMaxLength(50);
                entity.Property(e => e.ItemUnitsOfService).HasMaxLength(50);
                entity.Property(e => e.ItemCharges).HasMaxLength(50);
                entity.Property(e => e.ItemNonCoveredCharges).HasMaxLength(50);
                entity.Property(e => e.ItemPaymentApc).HasMaxLength(50);
                entity.Property(e => e.ItemAPCVersion).HasMaxLength(50);
            });
        }

        public virtual DbSet<LvAdmissionDischargeServices> LvAdmissionDischargeServices { get; set; }
        public virtual DbSet<LvAdmissionSources> LvAdmissionSources { get; set; }
        public virtual DbSet<LvAdmissionTypes> LvAdmissionTypes { get; set; }
        public virtual DbSet<LvCareProviderDepartments> LvCareProviderDepartments { get; set; }
        public virtual DbSet<LvCareProviderTypes> LvCareProviderTypes { get; set; }
        public virtual DbSet<LvCareProviders> LvCareProviders { get; set; }
        public virtual DbSet<LvChargeMasterCodeHcpcss> LvChargeMasterCodeHcpcss { get; set; }
        public virtual DbSet<LvChargeMasterDepartments> LvChargeMasterDepartments { get; set; }
        public virtual DbSet<LvDepartments> LvDepartments { get; set; }
        public virtual DbSet<LvDischargeStatus> LvDischargeStatus { get; set; }
        public virtual DbSet<LvEnterprises> LvEnterprises { get; set; }
        public virtual DbSet<LvFacilities> LvFacilities { get; set; }
        public virtual DbSet<LvFacilityGroups> LvFacilityGroups { get; set; }
        public virtual DbSet<LvFinancialClasses> LvFinancialClasses { get; set; }
        public virtual DbSet<LvPatientTypes> LvPatientTypes { get; set; }
        public virtual DbSet<LvPayers> LvPayers { get; set; }
        public virtual DbSet<LvSpecialties> LvSpecialties { get; set; }
        public virtual DbSet<LvVisitTypes> LvVisitTypes { get; set; }
        public virtual DbSet<VisitPatients> VisitPatients { get; set; }
        public virtual DbSet<vwInpatient> vwInpatient { get; set; }
        public virtual DbSet<vwOutpatient> vwOutpatient { get; set; }
        public virtual DbSet<vwOutpatientDetails> vwOutpatientDetails { get; set; }
    }
}
