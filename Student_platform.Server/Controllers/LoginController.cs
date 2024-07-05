using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_platform.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: api/<LoginController>
        [HttpGet]
        public string Get()
        {

            string con = "data source=.;initial catalog=smallterm;integrated security=True;";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            string com = "select * from user_info;";
            SqlCommand cmd = new SqlCommand(com, conn);


            SqlDataReader reader = cmd.ExecuteReader();
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
                    // 继续处理其他字段
                    string user_paw = reader["user_paw"].ToString();
                    user_info.Add(user_id, user_paw);
                }
            }

            reader.Close();
            conn.Close();

            // 将数据转换为 JSON 字符串
              string jsonData = JsonSerializer.Serialize(user_info);
            return jsonData;
        }

        [HttpGet("{name}")]
        public List<string> Get(string name)
        {
            List<string> list = new List<string>();



            return list;

        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

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
