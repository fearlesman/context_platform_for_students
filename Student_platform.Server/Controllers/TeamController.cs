 using Microsoft.AspNetCore.Mvc;
using Student_platform.Server.Modelclass;
using System.Data.SqlClient;

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

        // GET api/<TeamController>/5
        [HttpGet("{team_name}")]
        public string Get(string team_name)
        {
            





            string json = null;
            return json;
        }

        // POST api/<TeamController>
        [HttpPost]
        public IActionResult Post([FromBody] Team tm)
        {
            try { 
                DB db = new DB();
                string com = "insert into team_show values(@name,@leaderid,@leadername,@race,@description,@type,@currentmembers,@totalmembers,@status);";
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
                }
                // 执行命令并获取受影响的行数
                //对于查询操作（例如 SELECT 语句），如果使用 ExecuteScalar()，它将返回查询结果的第一行第一列的值。如果查询没有返回任何行，ExecuteScalar() 将返回 null（对于可空类型则是 DBNull）。
                //对于非查询操作（例如 INSERT, UPDATE, DELETE），如果使用 ExecuteNonQuery()，它将返回受影响的行数。如果返回的行数为期望的值，可以认为命令执行成功。
                
                DB db2 = new DB();
                string com2 = "insert into team_member values(@team_name,@member_name,@member_id);";
                db2.Connection(com2);
                using (db2.cmd)
                {
                    db2.cmd.Parameters.AddWithValue("@team_name", tm.name);
                    for (int i = 0; i < tm.members.Count(); i++)
                    {

                        db2.cmd.Parameters.AddWithValue("@member_name", tm.members[i].name);
                        db2.cmd.Parameters.AddWithValue("@member_id", tm.members[i].id);
                    }
                }

                DB db3 = new DB();
                string com3 = "insert into team_tags values(@team_name1,@tag1,@tag2,@tag3,@tag4,@tag5);";
                db3.Connection(com3);
                using (db3.cmd)
                {
                    db3.cmd.Parameters.AddWithValue("@team_name1", tm.name);
                    for (int i = 0; i < tm.tags.Count(); i++)
                    {
                        db3.cmd.Parameters.AddWithValue($"@tag{i}", tm.tags[i]);
                    }


                }
                
                return Ok("队伍创建成功");
            }
            catch (SqlException ex)
            {
                return BadRequest("队伍创建失败");
            }







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
