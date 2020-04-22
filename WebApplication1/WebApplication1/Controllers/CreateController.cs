using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using WebApplication1.Connect;

namespace WebApplication1.Controllers
{
    public class CreateController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string CreateUser(string id, string mail)
        {
            var rt = "";
            DBConnect dbconn = new DBConnect();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO USERDATE(id,mail)");
            sb.AppendLine(" VALUE (" + id + "," + mail);
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