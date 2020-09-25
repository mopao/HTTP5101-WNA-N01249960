using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_project.Controllers
{
    public class GreetingController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        //Returns the string “Greetings to {id} people!” where id is an integer value.
        public string Get(int id)
        {
            return "Greetings to "+id+" people!";
        }

        // POST api/<controller>
        public String Post([FromBody] string value)
        {
            return "Hello World!";
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}