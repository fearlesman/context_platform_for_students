using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text.Json;


//    string con = "data source=.;initial catalog=smallterm;integrated security=True;";
//SqlConnection conn = new SqlConnection(con);
//conn.Open();
//string com = "select * from my_info;";
//SqlCommand cmd = new SqlCommand(com, conn);
//conn.Close();


namespace Student_platform.Server
{
    public class Handler_t
    {
       

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json"; // 设置响应内容类型为 JSON


            string con = "data source=.;initial catalog=smallterm;integrated security=True;";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            string com = "select * from user_info;";
            SqlCommand cmd = new SqlCommand(com, conn);

      
            SqlDataReader reader = cmd.ExecuteReader();
            Dictionary<string,string> user_info = new Dictionary<string, string>();
            while (reader.Read())
            {
                // 读取每行数据的各个字段
                string user_id = reader["user_id"].ToString();
                // 继续处理其他字段
                string user_paw = reader["user_paw"].ToString();
                user_info.Add(user_id, user_paw);

            }

            reader.Close();
  

            conn.Close();
            // 模拟一些数据


            // 将数据转换为 JSON 字符串
            string jsonData = JsonSerializer.Serialize(user_info);

            // 将 JSON 数据写入响应流
            context.Response.WriteAsJsonAsync(jsonData);
        }

    }

   
}
