using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using WebApplication1.Connect;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UpdateController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody]UpdateModel data)
        {
            var rt = "";

            if (data.mail == null)
                rt = "資料不齊全";
            
            DBConnect dbconn = new DBConnect();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE USERDATE");
            sb.AppendLine("   SET mail" + data.mail);
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