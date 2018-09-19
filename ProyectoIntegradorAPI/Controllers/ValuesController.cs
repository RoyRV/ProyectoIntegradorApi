using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoIntegradorAPI.Controllers
{
    public class ValuesController : ApiController
    {
        List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
        
        public List<int> GetAll()
        {
            return numeros;
        }

        public string GetMessage() {
            return "jeje";
        }

        // GET api/values/5
        public int Get(int id)
        {
            return numeros.FirstOrDefault(x => x == id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
