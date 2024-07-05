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

        public bool has_team { get; set; }

        public string team_identity {  get; set; }
      

        public Stu(){}


        public Stu(string name,string major,string id,string paw,string[] skill,string[] chac,string identity,bool has = false) { 
            this.stu_name = name; 
            this.stu_major = major;
            this.user_id = id;
            this.user_paw = paw;
            this.stu_skill = skill;
            this.stu_character = chac;
            this.has_team = has; 
            this.team_identity = identity;
            
            
        }



        //学生信息的展示，返回json字符串
        public string Show(string name)
        {
            if (this.stu_name == name)
            {
                Stu obj = new Stu 
                {
                    user_id = this.user_id,
                    stu_name = this.stu_name,
                    stu_major = this.stu_major,
                    user_paw = this.user_paw,
                    stu_character = this.stu_character,
                    has_team = this.has_team,
                    team_identity = this.team_identity,
                };
                string json = JsonSerializer.Serialize(obj);
                return json;
            }
            else {
                return "not_match";
            }
        }




    }
}
