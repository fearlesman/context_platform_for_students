using Microsoft.AspNetCore.Mvc;
using Student_platform.Server.Modelclass;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_platform.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Quit_teamController : ControllerBase
    {
        // GET: api/<Quit_teamController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Quit_teamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Quit_teamController>
        [HttpPost]
        public string Post([FromBody] AQ_team qt)
        {









            return "ad";





        }

        // PUT api/<Quit_teamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Quit_teamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
