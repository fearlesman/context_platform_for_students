using Microsoft.AspNetCore.Mvc;
using Student_platform.Server.Modelclass;
using System.Data.SqlClient;
using System.Text.Json;

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
            //选出team_name
            string need_team_name = "  ";
            DB db  = new DB();
            string com = $"select name from team_show where race = {race_name};";
            db.Connection(com);
            using (db.cmd)
            {
                SqlDataReader reader = db.cmd.ExecuteReader();
                while (reader.Read())
                {
                    need_team_name = reader["name"].ToString();
                }
            }



                //选出team_member
                DB db1 = new DB();
            string com1 = $"select name,id from team_member where team_name = {need_team_name};";
            db1.Connection(com1);
            int maxmem = 1000;
            Team_member[] tm = new Team_member[maxmem];
            using (db1.cmd)
            {
                SqlDataReader reader1 = db1.cmd.ExecuteReader();
                while (reader1.Read())
                {
                    string name1 = reader1["team_name"].ToString();
                    if (name1 == need_team_name ) {
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
            string[] t_tags = new string[5];
            using (db2.cmd)
            {
                SqlDataReader reader2 = db2.cmd.ExecuteReader();
                while (reader2.Read())
                {
                    string name2 = reader2["team_name"].ToString();
                    if (name2 == need_team_name)
                    {
                        int i = 0;
                        t_tags[i] = reader2[$"tag{i + 1}"].ToString();
                        i++;
                    }

                }

            }

            //返回对应race-name下的队伍信息
            DB db3 = new DB();
            string com3 = "select * from team_show;";
            db3.Connection(com);
            int maxteamnum = 100;
            Team[] teams = new Team[100];
            using (db3.cmd)
            {
                SqlDataReader reader3 = db3.cmd.ExecuteReader();
                while (reader3.Read())
                {
                    int i = 0;

                    string race = reader3["race"].ToString();
                    if (race == race_name)
                    {

                        string t_name = reader3["name"].ToString();
                        string t_leaderid = reader3["leaderid"].ToString();
                        string t_leaderName = reader3["leaderName"].ToString();
                        string t_description = reader3["description"].ToString();
                        string t_type = reader3["type"].ToString();
                        int t_currentMembers = reader3.GetInt32(reader3.GetOrdinal("currentMembers"));  
                        int t_totalMembers = reader3.GetInt32(reader3.GetOrdinal("totalMembers"));
                        string t_status = reader3["status"].ToString();

                        teams[i] = new Team
                        {
                      
                            name = t_name,
                            leaderid = t_leaderid,
                            leaderName = t_leaderName,
                            members = tm,
                            race = race_name,
                            description = t_description,
                            type = t_type,
                            currentMembers = t_currentMembers,
                            totalMembers = t_totalMembers,
                            status = t_status,
                            tags = t_tags

                        };
                        i++;

                    }
                }
                string json = JsonSerializer.Serialize(teams);
                return json;
            }






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
