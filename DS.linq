<Query Kind="Program">
  <Reference>C:\FSharp\PM_DataGen\DataGenerator\packages\Fare.1.0.0\lib\net35\Fare.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\Microsoft.Reactive.Testing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Core.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Interfaces.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Linq.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.PlatformServices.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Providers.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Runtime.Remoting.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Windows.Forms.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Windows.Threading.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETCore\v4.5\System.Reactive.WindowsRuntime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\System.Web.Http.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\System.Web.Http.SelfHost.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\System.Web.Http.WebHost.dll</Reference>
  <Namespace>Microsoft.Win32</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Drawing.Printing</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	DataSet ds = new DataSet("LegacyDomain");
	ds.Tables.Add(LegacyDataSets.ForLegacyPatient());
	ds.Tables.Add(LegacyDataSets.ForLegacyEncounter());
	ds.GetXmlSchema().Dump();
}

public static class LegacyDataSets
    {
        private const string LegacyDomain = "LegacyDomain";

        /// <summary>
        /// Gets an empty DataTable for "LegacyPatient" as a member of "LegacyDomain" DataSet
        /// </summary>
        /// <returns>A defined instance</returns>
        public static DataTable ForLegacyPatient()
        {
            DataTable dt = new DataTable("LegacyPatient");
            dt.Columns.Add("LoadRowId", typeof(int)).AutoIncrement = true;
            dt.Columns.Add("PatientKey", typeof(int)).DefaultValue = default(int);
            dt.Columns.Add("SyncRoot", typeof(int)).DefaultValue = default(int);

            var dataCol = dt.Columns.Add("IsCancelled", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("MRN", typeof(string));
            dataCol.AllowDBNull = true;

            dt.Columns.Add("ShouldLoad", typeof(bool)).DefaultValue = default(bool);
            return dt;
        }

        /// <summary>
        /// Gets an empty DataTable for "LegacyEncounter" as a member of "LegacyDomain" DataSet
        /// </summary>
        /// <returns>A defined instance</returns>
        public static DataTable ForLegacyEncounter()
        {
            DataTable dt = new DataTable("LegacyEncounter");
            dt.Columns.Add("LoadRowId", typeof(int)).AutoIncrement = true;
            dt.Columns.Add("EncounterKey", typeof(int)).DefaultValue = default(int);
            dt.Columns.Add("SyncRoot", typeof(int)).DefaultValue = default(int);

            var dataCol = dt.Columns.Add("IsCancelled", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Address1", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Address1_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Address2", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Address2_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("AdmissionDate", typeof(DateTime));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("AdmissionDate_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("AdmissionDateYmd", typeof(DateTime));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("AdmissionDateYmd_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("AdmissionType", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("AdmissionType_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Age", typeof(int));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Age_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("AttendingPhysicianKey", typeof(int));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("AttendingPhysicianKey_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("ChiefComplaint", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("ChiefComplaint_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("City", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("City_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("CurrentLocation", typeof(int));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("CurrentLocation_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("DateOfBirth", typeof(DateTime));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("DateOfBirth_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("DischargeDate", typeof(DateTime));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("DischargeDate_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("DischargeDisposition", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("DischargeDisposition_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("EncounterNumber", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("EncounterNumber_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("FirstName", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("FirstName_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Gender", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Gender_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("LastName", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("LastName_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("MaritalStatus", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("MaritalStatus_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("MiddleName", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("MiddleName_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Mrn", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Mrn_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("PatientCurrentStatus", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("PatientCurrentStatus_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("PatientEncounterType", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("PatientEncounterType_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("PatientKey", typeof(int));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("PatientKey_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Payer", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Payer_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Payer_member", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Payer_member_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Race", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Race_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Race_member", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Race_member_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Religion", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Religion_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Religion_member", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Religion_member_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("SourceOfAdmission", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("SourceOfAdmission_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("SourceOfData", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("SourceOfData_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("State", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("State_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("UnitContacted", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("UnitContacted_tonull", typeof(bool));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Zip", typeof(string));
            dataCol.AllowDBNull = true;
            dataCol = dt.Columns.Add("Zip_tonull", typeof(bool));
            dataCol.AllowDBNull = true;

            dt.Columns.Add("ShouldLoad", typeof(bool)).DefaultValue = default(bool);
            return dt;
        }
    }

// Define other methods and classes here
