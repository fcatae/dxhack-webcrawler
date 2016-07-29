using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebCrawler.Controllers
{
    [Route("api/[controller]")]
    public class LinksController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> linkList = new List<string>();

            using (SqlConnection conn = new SqlConnection(@"Server=tcp:superbotdb.database.windows.net,1433;Initial Catalog=superbotdb;Persist Security Info=False;User ID=superbotdb;Password=P2ssw0rd@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                SqlCommand cmd = new SqlCommand("select 'http://bing.com' union select 'http://localhost'", conn);

                var reader = cmd.ExecuteReader();

                while( reader.Read() )
                {
                    string link = reader.GetString(0);
                    linkList.Add(link);
                }

            }

            return linkList;
        }

        // GET api/values/5
        [HttpGet("{keyw}")]
        public string Get(string keyw)
        {
            return keyw.ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
     
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
