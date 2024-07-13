using Microsoft.AspNetCore.Mvc;
using Student_platform.Server.Modelclass;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_platform.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuitTeamController : ControllerBase
    {
        // GET: api/<Quit_teamController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Quit_teamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        //退出队伍
        // POST api/Quit_team
        [HttpPost]
        public int Post(AQ_team qt)
        {

            string[] teams = new string[5];
             DB db = new DB();
            string com = "select * from user_team where user_id = @id;";
            db.Connection(com);
            db.cmd.Parameters.AddWithValue("@id", qt.user_id);
            using (db.cmd)
            {
                SqlDataReader reader = db.cmd.ExecuteReader();
                if (reader.Read())
                {
                    teams[0] = reader["user_team1"].ToString();
                    teams[1] = reader["user_team2"].ToString();
                    teams[2] = reader["user_team3"].ToString();
                    teams[3] = reader["user_team4"].ToString();
                    teams[4] = reader["user_team5"].ToString();
                    for (int i = 0; i < 5; i++)
                    {
                        if (teams[i] == qt.team_id)
                        {
                            DB db1 = new DB();
                            string com1 = "update user_team set @user_team = '' where user_id = @id;";
                            db1.Connection(com1);
                            db1.cmd.Parameters.AddWithValue("@user_team", "user_team" + (i + 1));
                            db1.cmd.Parameters.AddWithValue("@id", qt.user_id);
                            using (db1.cmd)
                            {
                               int result = db1.cmd.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    DB db2 = new DB();
                                    string com2 = "update team_show set currentMembers = currentMembers - 1 where team_id = @team_id;";
                                    db2.Connection(com2);
                                    db2.cmd.Parameters.AddWithValue("@team_id", qt.team_id);
                                    using (db2.cmd)
                                    {
                                        int result2 = db2.cmd.ExecuteNonQuery();
                                        if (result2 > 0)
                                        {
                                            db2.ChangeTeamStatus(qt.team_id, 1);
                                            return 1;
                                        }
                                    }
                                }
                            }

                      
                        }

                    }
                                         
                }

            }
            return 0;

        }

        // PUT api/<Quit_teamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Quit_teamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
