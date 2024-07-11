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
            this.conn.Open();

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
                while (reader1.Read())
                {


                    int i = 0;
                    tm.Add(new Team_member());
                    tm[i].name = reader1["name"].ToString();
                    tm[i].id = reader1["id"].ToString();
                    i++;

                }
            }
            return tm;
        }


        
        //选出tags
        public List<string> GetTags(string need_team_name)
        {
            DB db2 = new DB();
            string com2 = "select * from team_tags where team_name = @need_team_name;";
            db2.Connection(com2);
            db2.cmd.Parameters.AddWithValue("@need_tace_name",need_team_name);
            List<string> t_tags = new List<string>();
            using (db2.cmd)
            {
                SqlDataReader reader2 = db2.cmd.ExecuteReader();
                while (reader2.Read())
                { 
                        int i = 0;
                        t_tags.Add(new string(" "));

                        t_tags[i] = reader2[$"tag{i + 1}"].ToString();
                        i++;
                }

            }
            return t_tags;

        }

        ~DB()
        {

        this.conn.Close();
        }
    
    }
}
