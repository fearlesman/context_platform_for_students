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

        // POST api/<Stu_showController>
        [HttpPost]
        public void Post([FromBody] Stu stu)
        {





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
