using System;
using System.Data.SqlClient;



namespace Student_platform.Server
{
    public class info_search
    {


        public void Update()
        {
            
            string con = "data source=.;initial catalog=数据库名;integrated security=True;";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            string com = "select * from my_info;";
            SqlCommand cmd = new SqlCommand(com, conn);
            conn.Close();
        }



    }
}
