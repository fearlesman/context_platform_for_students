 using Microsoft.AspNetCore.Mvc;
using Student_platform.Server.Modelclass;
using System.Data.SqlClient;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_platform.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        // GET: api/<TeamController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        //根据时间获取队伍状态信息
        // GET api/<TeamController>/5
        [HttpGet("{date}")]
        public string Get(string date)
        {
            
            //选出team_name
            string need_team_name = "  ";
            List<Team_member> tm = new List<Team_member>();
            string[] t_tags = new string[5];
            DB db = new DB();
            string com =  "select * from team_show where end_date >= @date;";
            db.Connection(com);
            db.cmd.Parameters.AddWithValue("@date", date);
            List<Team> teams = new List<Team>();
            int   i = 0;
            using (db.cmd)
            {
                SqlDataReader reader = db.cmd.ExecuteReader();
                while (reader.Read())
                {
                    need_team_name = reader["name"].ToString();
                    tm = db.GetTeam_members(need_team_name);
                    t_tags = db.GetTags(need_team_name);

                    string t_name = reader["name"].ToString();
                    string t_leaderid = reader["leaderid"].ToString();
                    string t_leaderName = reader["leaderName"].ToString();
                    string race_name = reader["race"].ToString();
                    string t_description = reader["description"].ToString();
                    string t_type = reader["type"].ToString();
                    int t_id = reader.GetInt32(reader.GetOrdinal("id"));
                    int t_currentMembers = reader.GetInt32(reader.GetOrdinal("currentMembers"));
                    int t_totalMembers = reader.GetInt32(reader.GetOrdinal("totalMembers"));
                    int t_status = reader.GetInt32(reader.GetOrdinal("status"));
                    string end_date = reader["end_date"].ToString();
                    string university = reader["university"].ToString();
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
                reader.Close();

            }
                string json = JsonSerializer.Serialize(teams);
                return json;
       
           
        }


        //创建队伍
        // POST api/Team
        [HttpPost]
        public IActionResult Post([FromBody] Team tm)
        {
          
                DB db = new DB();
                string com = "insert into team_show values(@name,@leaderid,@leadername,@race,@description,@type,@currentmembers,@totalmembers,@status,@end_date,@university);";
                db.Connection(com);
                using (db.cmd)
                {
                    db.cmd.Parameters.AddWithValue("@name", tm.name);
                    db.cmd.Parameters.AddWithValue("@leaderid", tm.leaderid);
                    db.cmd.Parameters.AddWithValue("@leadername", tm.leaderName);
                    db.cmd.Parameters.AddWithValue("@race",tm.race );
                    db.cmd.Parameters.AddWithValue("@description", tm.description);
                    db.cmd.Parameters.AddWithValue("@type",tm.type );
                    db.cmd.Parameters.AddWithValue("@currentmembers",tm.currentMembers );
                    db.cmd.Parameters.AddWithValue("@totalmembers", tm.totalMembers);
                    db.cmd.Parameters.AddWithValue("@status", tm.status);
                    db.cmd.Parameters.AddWithValue("@end_date", tm.endTime);
                    db.cmd.Parameters.AddWithValue("@university", tm.university);
                int rows = db.cmd.ExecuteNonQuery();
                    if (rows > 0)
                {
                    DB db2 = new DB();
                    string com2 = "insert into team_member values(@team_name,@member_name,@member_id);";
                    db2.Connection(com2);
                    using (db2.cmd)
                    {
                        tm.members.Insert(0, new Team_member { name = tm.leaderName, id = tm.leaderid });
                        db2.cmd.Parameters.AddWithValue("@team_name", tm.name);
                        for (int i = 1; i < tm.members.Count()&&tm.members[i].name!=""&&tm.members[i].id!=""; i++)
                        {

                            db2.cmd.Parameters.AddWithValue("@member_name", tm.members[i].name);
                            db2.cmd.Parameters.AddWithValue("@member_id", tm.members[i].id);
                        }
                        int rows2 = db2.cmd.ExecuteNonQuery();
                        if (rows2 > 0)
                        {
                            DB db3 = new DB();
                            string com3 = "insert into team_tags values(@team_name1,@tag1,@tag2,@tag3,@tag4,@tag5);";
                            db3.Connection(com3);
                            using (db3.cmd)
                            {
                                db3.cmd.Parameters.AddWithValue("@team_name1", tm.name);
                                for (int i = 0; i < tm.tags.Count()&&tm.tags[i]!=""; i++)
                                {
                                    db3.cmd.Parameters.AddWithValue($"@tag{i}", tm.tags[i]);
                                }

                                int rows3 = db3.cmd.ExecuteNonQuery();
                                if (rows3 > 0)
                                {
                                    return Ok("队伍创建成功");
                                }
                               
                            }
                            }

                        }
            }
            // 执行命令并获取受影响的行数
            //对于查询操作（例如 SELECT 语句），如果使用 ExecuteScalar()，它将返回查询结果的第一行第一列的值。如果查询没有返回任何行，ExecuteScalar() 将返回 null（对于可空类型则是 DBNull）。
            //对于非查询操作（例如 INSERT, UPDATE, DELETE），如果使用 ExecuteNonQuery()，它将返回受影响的行数。如果返回的行数为期望的值，可以认为命令执行成功。

           
            }
                return BadRequest("队伍创建失败");
            




        }

        // PUT api/<TeamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
