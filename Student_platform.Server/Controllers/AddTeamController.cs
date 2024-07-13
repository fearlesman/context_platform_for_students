using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json;
using System.Data;
using Student_platform.Server.Modelclass;
using System.Net.NetworkInformation;

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
            int[] teams = new int[5];
            DB db1 = new DB();
            bool canJoin = db1.CanJoinTeam(at.team_id, at.user_id);
            if (!canJoin)
            {
                db1.ChangeTeamStatus(at.team_id, 0);
                return 0;
            }
            string com1 = "select user_team1,user_team2,user_team3,user_team4,user_team5 from user_teams where user_id = @user_id;";
            db1.Connection(com1);
            db1.cmd.Parameters.AddWithValue("@user_id", at.user_id);
            using (db1.cmd)
            {
                SqlDataReader reader1= db1.cmd.ExecuteReader();
                if (reader1.Read())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (reader1.IsDBNull(i))
                        {
                            DB db = new DB();
                            string com = $"update user_teams set @user_team = @team_id where user_id = @user_id;";
                            db.Connection(com);
                            db.cmd.Parameters.AddWithValue("@user_team", "user_team"+(i+1));
                            db.cmd.Parameters.AddWithValue("@user_id", at.user_id);
                            db.cmd.Parameters.AddWithValue("@team_id", at.team_id);
                            using (db.cmd)
                            {
                                int result = db.cmd.ExecuteNonQuery();
                                if (result > 0)
                                {

                                    DB db2 = new DB();
                                    string com2 = "update team_show set currentMembers = currentMembers + 1 where id = @team_id;";
                                    db2.Connection(com2);
                                    db2.cmd.Parameters.AddWithValue("@team_id", at.team_id);
                                    using (db2.cmd)
                                    {
                                        int result2 = db2.cmd.ExecuteNonQuery();
                                        if (result2 > 0)
                                        {
                                            DB db3 = new DB();
                                            string com3 = "select user_name from user_show where user_id = @user_id;";
                                            db3.Connection(com3);
                                            db3.cmd.Parameters.AddWithValue("@user_id", at.user_id);
                                            using (db3.cmd)
                                            {
                                                SqlDataReader reader = db3.cmd.ExecuteReader();
                                                if (reader.Read())
                                                {
                                                    string user_name = reader["user_name"].ToString();
                                                    DB db4 = new DB();
                                                    string com4 = "insert into team_member values(@team_id,@user_name,@user_id);";
                                                    db4.Connection(com4);
                                                    db4.cmd.Parameters.AddWithValue("@team_id", at.team_id);
                                                    db4.cmd.Parameters.AddWithValue("@user_id", at.user_id);
                                                    db4.cmd.Parameters.AddWithValue("@user_name", user_name);
                                                    int result3 = db4.cmd.ExecuteNonQuery();
                                                    if (result3 > 0)
                                                    {
                                                        return 1;
                                                    }
                                                }

                                            }

                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                reader1.Close();
            
           
               


           
                   
                
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
