using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_platform.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Add_teamController : ControllerBase
    {
        // GET: api/<Add_teamController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Add_teamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Add_teamController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Add_teamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Add_teamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
