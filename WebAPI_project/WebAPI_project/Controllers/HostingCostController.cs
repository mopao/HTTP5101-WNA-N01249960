using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_project.Controllers
{
    public class HostingCostController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public  IEnumerable<string> Get(int id)
        {
            double priceByFnight = 5.50;
            int fnightDays = 14;
            double hstRate = 0.13;

            double nberOfFngiht = id / fnightDays;
            double subtotal = Math.Round((Math.Floor(nberOfFngiht) * priceByFnight) + priceByFnight,2);
            double hst = Math.Round(subtotal * hstRate,2);
            double total = hst + subtotal;


            return new string[] { nberOfFngiht+" fornights at $"+priceByFnight+"/FN = "+subtotal+" CAD", 
                "HST "+hstRate+"% = $"+hst+" CAD", "Total = $"+total+" CAD"};
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
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