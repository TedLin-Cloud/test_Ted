using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using WebApplication1.Connect;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CreateController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<controller>
        public string Post([FromBody]CreateModel data)
        {
            var rt = "";
            if (data.id == null && data.mail == null)
            {
                rt = "資料不齊全";
            }
            
            DBConnect dbconn = new DBConnect();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO USERDATE(id,mail)");
            sb.AppendLine(" VALUE (" + data.id + "," + data.mail);
            var i = dbconn.DBExec(sb.ToString());

            if (i == 1)
            {
                rt = "新增成功";
            }
            else
            {
                rt = "新增失敗";
            }

            return rt;
        }
    }
}