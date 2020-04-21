using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace WebApplication1.Connect
{
    public class DBConnect
    {
        public int DBExec(string cmdstr)
        {
            var i = 0;
            var conStr = ConfigurationSettings.AppSettings["Tdb"].ToString();

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
    }
}
