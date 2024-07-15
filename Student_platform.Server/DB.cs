using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using Student_platform.Server.Modelclass;


namespace Student_platform.Server
{
    public class DB
    {
        public string con;
        
        public SqlConnection conn;

        public SqlCommand cmd;
        public DB() {
            this.con = "data source=.;initial catalog=smallterm;integrated security=True;Max Pool Size=1000;";
            this.conn = new SqlConnection(con);
            this.conn.Open();
           

        }


        public void Connection(string com)
        {
             this.cmd= new SqlCommand(com, conn);
           
        }

        //选出team_member
        public List<Team_member> GetTeam_members(int need_team_name)
        {
            DB db1 = new DB();
            string com1 = "select name,id from team_member where team_name = @need_team_name;";

            db1.Connection(com1);
            db1.cmd.Parameters.AddWithValue("@need_team_name", need_team_name);
            List<Team_member> tm = new List<Team_member>();
            using (db1.cmd)
            {
                SqlDataReader reader1 = db1.cmd.ExecuteReader();
                int i = 0;
                while (reader1.Read())
                {
                    tm.Add(new Team_member());
                    tm[i].name = reader1["name"].ToString();
                    tm[i].id = reader1["id"].ToString();
                    i++;

                }
                reader1.Close();
            }
            return tm;
        }


        
        //选出tags
        public string[] GetTags(int need_team_name)
        {
            DB db2 = new DB();
            string com2 = "select * from team_tags where team_name = @need_team_name;";
            db2.Connection(com2);
            db2.cmd.Parameters.AddWithValue("@need_team_name",need_team_name);
            string[] t_tags = new string[5];
            using (db2.cmd)
            {
            
                SqlDataReader reader2 = db2.cmd.ExecuteReader();
                while (reader2.Read())
                {
                    
                   
                        t_tags[0] = reader2["tag1"].ToString();
                        t_tags[1] = reader2["tag2"].ToString();
                        t_tags[2] = reader2["tag3"].ToString();
                        t_tags[3] = reader2["tag4"].ToString();
                        t_tags[4] = reader2["tag5"].ToString();
                       
                }
                reader2.Close();

            }
            return t_tags;

        }

        //判断是否能够加入队伍
        public bool CanJoinTeam(int team_name, string user_id)
        {
            DB db3 = new DB();
            string com3 = "select * from team_show where id = @team_name;";
            db3.Connection(com3);               
            db3.cmd.Parameters.AddWithValue("@team_name", team_name);
            bool can_join = true;
            using (db3.cmd)
            {
                SqlDataReader reader3 = db3.cmd.ExecuteReader();
                if (reader3.Read())
                {
                    int t_currentMembers = reader3.GetInt32(reader3.GetOrdinal("currentMembers"));
                    int t_totalMembers = reader3.GetInt32(reader3.GetOrdinal("totalMembers"));
                    if (t_currentMembers >= t_totalMembers)
                    {
                        can_join = false;
                    }
                }
                reader3.Close();
            }
            return can_join;
        }

        //改变队伍status
        public void ChangeTeamStatus(int team_name, int status)
        {
            DB db4 = new DB();
            string com4 = "update team_show set status = @status where id = @team_name;";
            db4.Connection(com4);
            db4.cmd.Parameters.AddWithValue("@status", status);
            db4.cmd.Parameters.AddWithValue("@team_name", team_name);
            using (db4.cmd)
            {
                db4.cmd.ExecuteNonQuery();
            }
        }


        //检查该用户是否在该队伍中
        public bool IsInTeam(int team_name, string user_id)
        {
            DB db5 = new DB();
            string com5 = "select * from team_member where team_name = @team_name and id = @user_id;";  
            db5.Connection(com5);
            db5.cmd.Parameters.AddWithValue("@team_name", team_name);
            db5.cmd.Parameters.AddWithValue("@user_id", user_id);
            bool is_in_team = false;
            using (db5.cmd)
            {
                SqlDataReader reader5 = db5.cmd.ExecuteReader();
                if (reader5.Read())
                {
                    is_in_team = true;
                }
                reader5.Close();
            }
            return is_in_team;
        }
        //从team_show中选出team_id
        public int chooseid(string name)
        {
            DB db  = new DB();
            string com = "select id from team_show where name = @team_name;";
            db.Connection(com);
            db.cmd.Parameters.AddWithValue ("@team_name", name);
            using (db.cmd)
            {
                SqlDataReader reader = db.cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = 0;
                    id = reader .GetInt32("id");
                    return id; 
                }
            }
            return -1;
        }

         ~DB()
        {

        this.conn.Close();
        }
    
    }
}
