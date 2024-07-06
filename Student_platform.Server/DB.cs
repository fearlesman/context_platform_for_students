using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;


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

        ~DB()
        {

        this.conn.Close();
        }
    
    }
}
