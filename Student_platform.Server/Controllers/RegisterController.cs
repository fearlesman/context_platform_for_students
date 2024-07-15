using Microsoft.AspNetCore.Mvc;
using Student_platform.Server.Modelclass;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


        //注册
        // POST api/Register
        [HttpPost]
        public IActionResult Post([FromBody] Register reg)
        {
           
                DB db = new DB();
                string com = "insert into user_info(user_id,user_paw,user_email,university) values(@id,@paw,@email,@university);";
                db.Connection(com);
                using (db.cmd)
                {
                    db.cmd.Parameters.AddWithValue("@id", reg.username);
                    db.cmd.Parameters.AddWithValue("@paw", reg.password);
                    db.cmd.Parameters.AddWithValue("@email", reg.email);
                    db.cmd.Parameters.AddWithValue("@university", reg.university);
                }

            DB db2 = new DB();
            string com2 = "insert into user_show(user_id) values(@user_id);";
            db2.Connection(com2);
            using (db2.cmd)
            {
                db2.cmd.Parameters.AddWithValue("@user_id", reg.username);
            }

            DB db3 = new DB();
            string com3 = "insert into user_teams(user_id) values(@user);";
            db3.Connection(com3);
            db3.cmd.Parameters.AddWithValue("@user", reg.username);
            
            DB db4 = new DB();
            string com4 = "insert into user_show(user_id, head_img) values(@user_id,@head_img);";
            db4.Connection(com4);
            db4.cmd.Parameters.AddWithValue("@user_id", reg.username);
            db4.cmd.Parameters.AddWithValue("@head_img", reg.head_img);




            // 执行命令并获取受影响的行数
            try
            {

                int rowsAffected = db.cmd.ExecuteNonQuery();
                int rowsAffected2 = db2.cmd.ExecuteNonQuery();
                int rowsAffected3 = db3.cmd.ExecuteNonQuery();
                int rowsAffected4 = db4.cmd.ExecuteNonQuery();
                db.Close();
                db2.Close();
                db3.Close();
                db4.Close();
                if (rowsAffected > 0&&rowsAffected2>0&&rowsAffected3>0&&rowsAffected4> 0)
                {
                    return Ok("注册成功");
                }
                return BadRequest("注册失败");
            
             
            }
            catch (SqlException ex)
            {
                return BadRequest( "用户名已存在。");
            }



}
    //int rowsAffected = db.cmd.ExecuteNonQuery();

    //        // 检查受影响的行数
    //        if (rowsAffected > 0)
    //        {
    //            return Ok("注册成功");
    //        }
    //        else
    //        {
    //            return BadRequest("注册失败");
    //        }
          
    //    }
                         





        

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
