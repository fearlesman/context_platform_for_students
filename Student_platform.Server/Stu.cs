using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace Student_platform.Server
{
    public class Stu
    {
        public string user_id { get; set; }

        public string user_paw {  get; set; }
        public string stu_name { get; set; }

        public string stu_major { get; set; }

        public string[] stu_skill { get; set; }

        public string[] stu_character {  get; set; }

        public bool has_team = false;

        public string[] team_identity = { "队员", "队长" };
      

        public Stu(){}


        public Stu(string name,string major) { 
            this.stu_name = name; 
            this.stu_major = major;
            
            
        }



        //学生信息的展示，返回json字符串
        public string Show()
        {
            Stu obj = new Stu
            {
                stu_name = this.stu_name,
                stu_major = this.stu_major,
                
            };


            string json = JsonSerializer.Serialize(obj); 
            return json;
        }
    }
}
