using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json;
using System.Data;
using Student_platform.Server.Modelclass;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_platform.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //一些基础语法
        // GET: api/<LoginController>
        [HttpGet]
        public string Get()
        {
            
            DB db = new DB();
            string com = "select * from user_info;";
            db.Connection(com);
            SqlDataReader reader = db.cmd.ExecuteReader();
            Dictionary<string, string> user_info = new Dictionary<string, string>();
            while (reader.Read())
            {
                // 读取每行数据的各个字段
                if (reader["user_id"] == null || reader["user_paw"] == null)
                {
                    reader.Read();
                }
                else
                {
                    string user_id = reader["user_id"].ToString();
                    string user_paw = reader["user_paw"].ToString();
                    user_info.Add(user_id, user_paw);
                }
            }

            reader.Close();
            db.conn.Close();

            // 将数据转换为 JSON 字符串
              string jsonData = JsonSerializer.Serialize(user_info);
            return jsonData;
        }

        //登录
        //  api/Login/{user_info}
        [HttpPost]
        public bool Post(Login user_info )
        {
            DB db = new DB();
            
            string com = "select * from user_info where user_id = @name;";
            db.Connection(com);
            using (db.cmd)
            {
                db.cmd.Parameters.AddWithValue("@name", user_info.username);
                SqlDataReader reader = db.cmd.ExecuteReader();
                if (reader.Read())
                {
                    string paw = reader["user_paw"].ToString();
           
                    if (paw == user_info.password)
                    {
                        DB db1 = new DB();
                        string com1 = "update user_info set user_status = 1 where user_id = @user_name;";
                        db1.Connection(com1);
                        using (db1.cmd)
                        {
                            db1.cmd.Parameters.AddWithValue("@user_name", user_info.username);
                        }
                        return true;
                    }
                }
                reader.Close();
                
             
                return false;
            }
            
      

        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        //[HttpPost]
        //public IActionResult Post([FromBody] string value)
        //{
        //    if (string.IsNullOrEmpty(value))
        //    {
        //        return BadRequest("Value cannot be null or empty");
        //    }

        //    // 处理接收到的值
        //    return Ok($"Received value: {value}");
        //}

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}


//// 执行命令并获取受影响的行数
//int rowsAffected = command.ExecuteNonQuery();

//// 检查受影响的行数
//if (rowsAffected > 0)
//{
//    Console.WriteLine("插入成功");
//}
//else
//{
//    Console.WriteLine("插入失败");
//}
//                }
//            }
//            catch (SqlException ex)
//            {
//                // 捕获SQL异常
//                Console.WriteLine($"插入失败: {ex.Message}");
//            }