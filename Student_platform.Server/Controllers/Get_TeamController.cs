using Microsoft.AspNetCore.Mvc;
using Student_platform.Server.Modelclass;
using System.Data.SqlClient;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_platform.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Get_TeamController : ControllerBase
    {
        // GET: api/<Get_TeamController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Get_TeamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Get_TeamController>
        [HttpPost]
        public string Post([FromBody] string user_name)
        {
            int[] team_name = new int[5] { 0, 0, 0, 0, 0 };
            DB db = new DB();
            string com = "select * from user_teams where user_id = @user_name;";
            db.Connection(com);
            db.cmd.Parameters.AddWithValue("@user_name", user_name);
            using (db.cmd)
            {
                SqlDataReader reader = db.cmd.ExecuteReader();
                if (reader.Read())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            team_name[i] = reader.GetInt32(reader.GetOrdinal("user_team" + (i + 1)));
                        }
                    }
                }

            }
            db.DB_Close();
            List<Team> teams = new List<Team>();
            for (int j = 0; j < 5 && team_name[j] != 0; j++)
            {
                int need_team_name = team_name[j];
                List<Team_member> tm = new List<Team_member>();
                string[] t_tags = new string[5];
                //返回对应race-name下的队伍信息
                DB db3 = new DB();
                string com3 = "select * from team_show where id = @need_team_name;";
                db3.Connection(com3);

                db3.cmd.Parameters.AddWithValue("@need_team_name", need_team_name);
               
                using (db3.cmd)
                {
                    SqlDataReader reader3 = db3.cmd.ExecuteReader();
                    int i = 0;
                    while (reader3.Read())
                    {

                        tm = db3.GetTeam_members(need_team_name);
                        t_tags = db3.GetTags(need_team_name);
                        string t_name = reader3["name"].ToString();
                        string t_leaderid = reader3["leaderid"].ToString();
                        string t_leaderName = reader3["leaderName"].ToString();
                        string t_description = reader3["description"].ToString();
                        string t_type = reader3["type"].ToString();
                        string race_name = reader3["race"].ToString();
                        int t_id = reader3.GetInt32(reader3.GetOrdinal("id"));
                        int t_currentMembers = reader3.GetInt32(reader3.GetOrdinal("currentMembers"));
                        int t_totalMembers = reader3.GetInt32(reader3.GetOrdinal("totalMembers"));
                        int t_status = reader3.GetInt32(reader3.GetOrdinal("status"));
                        string end_date = reader3["end_date"].ToString();
                        string university = reader3["university"].ToString();
                        teams.Add(new Team());
                        teams[i] = new Team
                        {

                            name = t_name,
                            leaderid = t_leaderid,
                            leaderName = t_leaderName,
                            members = tm,
                            university = university,
                            race = race_name,
                            description = t_description,
                            type = t_type,
                            currentMembers = t_currentMembers,
                            id = t_id,
                            totalMembers = t_totalMembers,
                            status = t_status,
                            tags = t_tags

                        };
                        i++;


                    }
                    reader3.Close();

                }
            }
            string json = JsonSerializer.Serialize(teams);

            return json;

        }

        // PUT api/<Get_TeamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Get_TeamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
