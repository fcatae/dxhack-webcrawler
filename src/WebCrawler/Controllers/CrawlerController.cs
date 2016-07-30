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
    public class CrawlerController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "OK";
        }
        
    }
}
