using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an
{
    class Database
    {
        public static SqlDataAdapter adapter;
        public static SqlCommand cmd;
        public string conStr = @"Data Source=SOAZ\SQLEXPRESS;Initial Catalog=QLMUABAN;Integrated Security=True";
        public SqlConnection getConnection()
        {
            return new SqlConnection(conStr);
        }
        
        public DataTable getAllData(string query)
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection con = getConnection())
                {
                    con.Open();
                    adapter = new SqlDataAdapter(query, con);
                    adapter.Fill(dataTable);
                    con.Close();
                }

                if (dataTable.Rows.Count == 0)
                {
                    return null;
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
