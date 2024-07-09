using Microsoft.AspNetCore.Mvc;
using Student_platform.Server.Modelclass;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_platform.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        // GET: api/<RaceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RaceController>/race_name
        [HttpGet("{race_name}")]
        public string Get(string race_name)
        {

   
            //选出team_member
            DB db1 = new DB();
            string com1 = $"select name,id from team_member where team_name = (select name from team_show where race = {race_name});";
            db1.Connection(com1);
            int maxmem = 1000;
            Team_member[] tm = new Team_member[maxmem];
            using (db1.cmd)
            {
                SqlDataReader reader1 = db1.cmd.ExecuteReader();
                while (reader1.Read())
                {
                    string name1 = "reader->team_name";
                    if (name1 =="need team_name" ) {
                        int i = 0;
                        tm[i] = new Team_member();
                        tm[i].name = reader1["name"].ToString();
                        tm[i].id = reader1["id"].ToString();
                        i++;
                    }
                }
            }

            //选出tags
            DB db2 = new DB();
            string com2 = $"select * from team_tags where team_name = (select name from team_show where race = {race_name});";
            db2.Connection(com2);
            string[] tags = new string[5];
            using (db2.cmd)
            {
                SqlDataReader reader1 = db2.cmd.ExecuteReader();
                while (reader1.Read())
                {
                    int i = 0;
                    tags[i] = reader1[$"tag{i + 1}"].ToString();
                    i++;


                }

            }

            //返回对应race-name下的队伍信息
            DB db = new DB();
            string com = "select * from team_show;";
            db.Connection(com);






            return "value";
        }

        // POST api/<RaceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RaceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RaceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
