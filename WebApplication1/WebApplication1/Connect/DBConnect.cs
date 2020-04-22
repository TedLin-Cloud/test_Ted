using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace WebApplication1.Connect
{
    public class DBConnect
    {
        protected string conStr = ConfigurationSettings.AppSettings["Tdb"].ToString();

        public int DBExec(string cmdstr)
        {
            var i = 0;
            using (var conn = new SqlConnection(conStr))
            {
                using (var cmd = new SqlCommand(cmdstr))
                {
                    conn.Open();
                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }

        public DataTable SqlQueryDt(string cmdstr)
        {
            var ds = new DataSet();
            using (var conn = new SqlConnection(conStr))
            {
                var da = new SqlDataAdapter(cmdstr, conn);
                da.Fill(ds);
            }

            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }
    }
}
