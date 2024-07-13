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
    public class AddTeamController : ControllerBase
    {
        // GET: api/<Add_teamController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1" };
        //}

        //// GET api/<Add_teamController>/5
        //[HttpGet("{user_name}")]
        //public string Get(string  user_name)
        //{
        //    return "value";
        //}



        //加入队伍
        // POST api/Add_team
        [HttpPost]
        public int Post( AQ_team at)
        {
            string[] teams = new string[5];
            DB db1 = new DB();
            string com1 = "select user_team1,user_team2,user_team3,user_team4,user_team5 from user_teams where user_id = @user_id;";
            db1.Connection(com1);
            db1.cmd.Parameters.AddWithValue("@user_id", at.user_id);
            using (db1.cmd)
            {
                SqlDataReader reader1= db1.cmd.ExecuteReader();
                if (reader1.Read())
                {
                    teams[0] = reader1["user_team1"].ToString();
                    teams[1] = reader1["user_team2"].ToString();
                    teams[2] = reader1["user_team3"].ToString();
                    teams[3] = reader1["user_team4"].ToString();
                    teams[4] = reader1["user_team5"].ToString();
                }
                reader1.Close();
            }
            for (int i = 0; i < 5; i++)
            {
                if(teams[i] == at.team_id)
                {
                    return -1;
                }
                if (teams[i] == null)
                {
                    DB db = new DB();
                    string com = $"insert into user_teams(user_id,user_team{i+1}) values(@user_id,@team_id);";
                    db.Connection(com);
                    db.cmd.Parameters.AddWithValue("@user_id", at.user_id);
                    db.cmd.Parameters.AddWithValue("@team_id", at.team_id);
                    using (db.cmd)
                    {
                        int result = db.cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            DB db2 = new DB();
                            string com2 = "update team_show set currentMembers = currentMembers + 1 where team_id = @team_id;";
                            db2.Connection(com2);
                            db2.cmd.Parameters.AddWithValue("@team_id", at.team_id);
                            using (db2.cmd)
                            {
                                int result2 = db2.cmd.ExecuteNonQuery();
                                if (result2 > 0)
                                {
                                    return 1;
                                }
                            }
                        }
                    }


           
                   
                }
            }
            return 0;


        }

        // PUT api/<Add_teamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Add_teamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
