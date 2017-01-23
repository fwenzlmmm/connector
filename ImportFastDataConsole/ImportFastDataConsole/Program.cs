using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportFastDataConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "Data Source=usjnridap01;Initial Catalog=ClientDB_237006;uid=HSA_DBUSER;pwd=H!3tdY9IO7kZ367;";
            IEnumerable<string> inpatientRaw = ReadAsLines(@"C:\HubFiles\Samples\Inpatient360ExportServiceData_20130401_20130405_20170113_191049939.txt");
            IEnumerable<string> inpatientProvidersRaw = ReadAsLines(@"C:\HubFiles\Samples\Inpatient360ExportServiceData_20130401_20130405_20170113_191049939VisitProviders.txt");
            IEnumerable<string> outpatientRaw = ReadAsLines(@"C:\HubFiles\Samples\Outpatient360ExportServiceData_20131018_20131018_20170113_191057602.txt");
            IEnumerable<string> outpatientDetailsRaw = ReadAsLines(@"C:\HubFiles\Samples\Outpatient360ExportServiceData_20131018_20131018_20170113_191057602Details.txt");
            IEnumerable<string> outpatientProvidersRaw = ReadAsLines(@"C:\HubFiles\Samples\Outpatient360ExportServiceData_20131018_20131018_20170113_191057602VisitProviders.txt");

            CallSqlProcedure(connection, "LoadPrepareInOutPatientData");

            var dtInpatient = new DataTable();
            var dtInpatientProviders = new DataTable();
            var dtOutpatient = new DataTable();
            var dtOutpatientDetails = new DataTable();
            var dtOutpatientProviders = new DataTable();

            LoadDataTable(dtInpatient, inpatientRaw);
            LoadDataTable(dtInpatientProviders, inpatientProvidersRaw);
            LoadDataTable(dtOutpatient, outpatientRaw);
            LoadDataTable(dtOutpatientDetails, outpatientDetailsRaw);
            LoadDataTable(dtOutpatientProviders, outpatientProvidersRaw);

            BulkLoadToDB(connection, "dbo.Inpatient_Load", dtInpatient);
            BulkLoadToDB(connection, "dbo.InpatientProviders_Load", dtInpatientProviders);
            BulkLoadToDB(connection, "dbo.Outpatient_Load", dtOutpatient);
            BulkLoadToDB(connection, "dbo.OutpatientDetails_Load", dtOutpatientDetails);
            BulkLoadToDB(connection, "dbo.OutpatientProviders_Load", dtOutpatientProviders);

            CallSqlProcedure(connection, "LoadInOutPatientData");
        }
        static IEnumerable<string> ReadAsLines(string filename)
        {
            using (var reader = new StreamReader(filename))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }

        static void LoadDataTable(DataTable dt, IEnumerable<string> data)
        {
            //this assume the first record is filled with the column names
            var headers = data.First().Split('|');
            foreach (var header in headers)
                dt.Columns.Add(header);
            var records = data.Skip(1);
            foreach (var record in records)
                dt.Rows.Add(record.Split('|'));
        }

        static void BulkLoadToDB(string connection, string dbTableName, DataTable dt)
        {
            using (SqlConnection destinationConnection = new SqlConnection(connection))
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
            {
                destinationConnection.Open();
                bulkCopy.DestinationTableName = dbTableName;
                bulkCopy.WriteToServer(dt);
            }
        }

        static void CallSqlProcedure(string connection, string pocedureName)
        {
            using (SqlConnection destinationConnection = new SqlConnection(connection))
            {
                destinationConnection.Open();
                SqlCommand cmd = new SqlCommand(pocedureName, destinationConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
