using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApplication1.Connect;

namespace WebApplication1.Controllers
{
    public class SelectController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(string id)
        {
            var str_json = "";
            DBConnect dbconn = new DBConnect();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT * FROM USERDATE");
            var dt = dbconn.SqlQueryDt(sb.ToString());
            //將DataTable轉成JSON字串
            if (dt.Rows.Count == 0)
                str_json = "查無資料";
            else
                str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);

            return str_json;

        }
    }
}