using ExcelDataReader;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Data.OleDb;

namespace Summatix.Automation.Core
{
    public class ExcelUtil
    {
        private readonly string _filePath = string.Empty;

        public ExcelUtil()
        {

        }

        
        public ExcelUtil(string filePath)
        {
            _filePath = filePath;
        }

        public DataSet ImportDataintoDataset(string fileName)
        {
            string connectionString =
                string.Format("provider=Microsoft.ACE.OLEDB.12.0; data source={0};Extended Properties='Excel 12.0 Xml; HDR=YES;'", fileName);


            DataSet data = new DataSet();

            string sheetName = GetExcelSheetName(connectionString);
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                var dataTable = new DataTable();
                string query = string.Format("SELECT * FROM [{0}]", sheetName);
                con.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                adapter.Fill(dataTable);
                data.Tables.Add(dataTable);
            }


            return data;
        }

        string GetExcelSheetName(string connectionString)
        {
            OleDbConnection con = null;
            DataTable dt = null;
            string excelSheetName = string.Empty;
            con = new OleDbConnection(connectionString);
            con.Open();
            dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt != null)
            {
                excelSheetName = dt.Rows[0]["TABLE_NAME"].ToString();
                return excelSheetName;
            }
            else
                return null;
        }


    }
}
