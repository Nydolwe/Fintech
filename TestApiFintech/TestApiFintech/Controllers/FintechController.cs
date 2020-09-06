using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TestApiFintech.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApiFintech.Controllers
{
    [Route("api/[controller]")]
    public class FintechController : Controller
    {
        // GET: api/<controller>
        [HttpGet("Get")]
        public string Get()
        {
            Bot bot = new Bot();

            return bot.GetToken();
        }

        [HttpGet("GetBot")]
        public string GetBot()
        {
            Bot bot = new Bot();

            bot.AllFunction();

            return "";
        }

        [HttpGet("GetFireHoseAccountsAtBank")]
        public List<Customers> GetFireHoseAccountsAtBank()
        {
            Bot bot = new Bot();
            return bot.GetFireHoseAccountsAtBank();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
