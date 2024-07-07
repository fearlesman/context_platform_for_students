using Microsoft.AspNetCore.Mvc;
using Student_platform.Server.Modelclass;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_platform.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        // GET: api/<RegisterController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // POST api/Register
        [HttpPost]
        public IActionResult Post([FromBody] Register reg)
        {
            
            DB db = new DB();
            try
            {
                string com = "insert into user_info(user_id,user_paw,user_email) values(@id,@paw,@email);";
                db.Connection(com);
                using (db.cmd)
                {
                    db.cmd.Parameters.AddWithValue("@id", reg.username);
                    db.cmd.Parameters.AddWithValue("@paw", reg.password);
                    db.cmd.Parameters.AddWithValue("@email", reg.email);
                }

                return Ok("注册成功");

            }
            catch (SqlException ex)
            {
                return BadRequest("注册失败");
            }
           
           
        }
                         





        

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
