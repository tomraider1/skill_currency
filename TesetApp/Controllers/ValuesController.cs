using DemoWindowsApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TesetApp.Controllers
{
    public class ValuesController : ApiController
    {
        DBConnect context = new DBConnect();
        // GET: api/Values
        public IEnumerable<string> Get()
        {
           
            return (new List<string>{ "Value1", "value2" , "Value3" });
        }

        // GET: api/Values/5
        public string Get(int id)
        {
            
            return "value";
        }

        // POST: api/Values
        public void Post([FromBody]Person p)
        {
            
        }

        // PUT: api/Values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Values/5
        public void Delete(int id)
        {
        }
    }
}