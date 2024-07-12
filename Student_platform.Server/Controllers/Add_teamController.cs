using Microsoft.AspNetCore.Mvc;
using Student_platform.Server.Modelclass;

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
        [HttpGet("{user_name}")]
        public string Get(string  user_name)
        {
            return "value";
        }

        // POST api/<Add_teamController>
        [HttpPost]
        public void Post([FromBody] AQ_team at)
        {
            DB db = new DB();
            string com = "insert into user_teams values(@user_id,@user_team1,@user_team2,@user_team3,@user_team4,@user_team5);";
            db.Connection(com);
            db.cmd.Parameters.AddWithValue("@user_id", at.user_id);
            db.cmd.Parameters.AddWithValue("@user_team1", at.team_name);
           


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
