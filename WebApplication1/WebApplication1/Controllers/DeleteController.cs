using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Connect;

namespace WebApplication1.Controllers
{
    public class DeleteController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Delete(string id)
        {
            var rt = "";
            DBConnect dbconn = new DBConnect();
            var i = dbconn.DBExec("DELETE FROM USERDATE WHERE ID = " + id);
            
            if(i == 1)
            {
                rt = "刪除成功";
            }
            else
            {
                rt = "刪除失敗";
            }

            return rt;
        }
    }
}