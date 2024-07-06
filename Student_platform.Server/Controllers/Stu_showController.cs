using Microsoft.AspNetCore.Mvc;
using Student_platform.Server.Modelclass;
using System.Data.SqlClient;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_platform.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Stu_showController : ControllerBase
    {
        // GET: api/<Stu_showController>
        [HttpGet]
        public string Get()
        {
            return "a";
        }

        //获取简历信息
        // GET api/Stu_show/{user_id}
        [HttpGet("{id}")]
        public string Get(string id)
        {
            DB db = new DB();
            string com = "select * from user_show where user_id = @id;";
            db.Connection(com);
            SqlDataReader reader = db.cmd.ExecuteReader();
            db.cmd.Parameters.AddWithValue("@id", id);

            Stu obj = new Stu
            {
                user_id = reader["user_id"].ToString(),
                stu_name = reader["user_name"].ToString(),
                stu_major = reader["user_major"].ToString(),
                stu_skill = reader["user_skill"].ToString(),
                stu_character = reader["user_character"].ToString(),
                has_team = reader.GetBoolean(5),
                team_identity = reader["user_identity"].ToString()
            };
            string json = JsonSerializer.Serialize(obj);
            return json;

       
        }

        // POST api/Stu_show
        [HttpPost]
        public IActionResult Post([FromBody] Stu stu)
        {
            DB dB = new DB();
            string com = "insert into user_show values(@id,@name,@major,@skill,@character,@team,@identity);";
            dB.Connection(com);
            dB.cmd.Parameters.AddWithValue("@id",stu.user_id);
            dB.cmd.Parameters.AddWithValue("@name",stu.stu_name);
            dB.cmd.Parameters.AddWithValue("@major",stu.stu_major);
            dB.cmd.Parameters.AddWithValue("@skill",stu.stu_skill);
            dB.cmd.Parameters.AddWithValue("@character",stu.stu_character);
            dB.cmd.Parameters.AddWithValue("@team",stu.has_team);
            dB.cmd.Parameters.AddWithValue("@identity",stu.team_identity);

            int rowsAffected = dB.cmd.ExecuteNonQuery();

            // 检查受影响的行数
            if (rowsAffected > 0)
            {
                return Ok("保存成功");
            }
            else
            {
                return BadRequest("保存失败");
            }






        }

        // PUT api/<Stu_showController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Stu_showController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
