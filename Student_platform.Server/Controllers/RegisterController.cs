﻿using Microsoft.AspNetCore.Mvc;
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



        // POST api/Register
        [HttpPost]
        public IActionResult Post([FromBody] Register reg)
        {

            DB db = new DB();


            string com = "insert into user_info(user_id,user_paw,user_email) values(@id,@paw,@email);";
            db.Connection(com);
            using (db.cmd)
            {
                db.cmd.Parameters.AddWithValue("@id", reg.username);
                db.cmd.Parameters.AddWithValue("@paw", reg.password);
                db.cmd.Parameters.AddWithValue("@email", reg.email);
            }
            // 执行命令并获取受影响的行数
            try { 
                db.cmd.ExecuteScalar();
                return Ok("注册成功");
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