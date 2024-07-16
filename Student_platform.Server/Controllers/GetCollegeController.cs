using Microsoft.AspNetCore.Mvc;
using Student_platform.Server.Modelclass;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_platform.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCollegeController : ControllerBase
    {
        // GET: api/<Get_collegeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Get_collegeController>/5
        [HttpGet("{id}")]
        public string Get( string id)
        {

            DB db = new DB();
            string com = "select university from user_info where user_id = @id;";
            db.Connection(com);
            db.cmd.Parameters.AddWithValue("@id", id);
            using (db.cmd)
            {
                SqlDataReader reader = db.cmd.ExecuteReader();
                if (reader.Read())
                {
                    string uni = reader["university"].ToString();
                    db.DB_Close();
                    return uni;
                }
                else
                {
                    db.DB_Close();
                    return "Not found";
                }
            }

          
        }

        // POST api/<Get_collegeController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<Get_collegeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Get_collegeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
