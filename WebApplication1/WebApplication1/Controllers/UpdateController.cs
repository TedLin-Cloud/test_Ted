using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using WebApplication1.Connect;

namespace WebApplication1.Controllers
{
    public class UpdateController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string updateUser(string id, string mail)
        {
            var rt = "";
            DBConnect dbconn = new DBConnect();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE USERDATE");
            sb.AppendLine("   SET mail" + mail);
            sb.AppendLine(" WHERE id" + id);
            var i = dbconn.DBExec(sb.ToString());

            if (i == 1)
            {
                rt = "修改成功";
            }
            else
            {
                rt = "修改失敗";
            }

            return rt;
        }
    }
}