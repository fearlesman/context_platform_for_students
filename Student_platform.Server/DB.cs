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
             this.con = "data source=.;initial catalog=smallterm;integrated security=True;";
             this.conn = new SqlConnection(con);
            if (conn.State != ConnectionState.Open)
            {
                this.conn.Open();
            }

        }


        public void Connection(string com)
        {
             this.cmd= new SqlCommand(com, conn);
           
        }

        //选出team_member
        public List<Team_member> GetTeam_members(string need_team_name)
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
        public string[] GetTags(string need_team_name)
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

        ~DB()
        {

        this.conn.Close();
        }
    
    }
}
