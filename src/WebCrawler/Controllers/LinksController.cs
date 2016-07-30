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
                SqlCommand cmd = new SqlCommand("select link from tbLinks", conn);
                conn.Open();

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
        public IEnumerable<string> Get(string keyw)
        {
            List<string> linkList = new List<string>();

            string keyword_list = keyw.Replace("|"," ");

            using (SqlConnection conn = new SqlConnection(@"Server=tcp:superbotdb.database.windows.net,1433;Initial Catalog=superbotdb;Persist Security Info=False;User ID=superbotdb;Password=P2ssw0rd@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                SqlCommand cmd = new SqlCommand("SELECT link FROM TBLINKS WHERE FREETEXT(body, @1)", conn);
                var p1 = cmd.Parameters.Add("@1", SqlDbType.VarChar, 1000);
                p1.Value = keyword_list;

                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string link = reader.GetString(0);
                    linkList.Add(link);
                }

            }

            return linkList;
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
