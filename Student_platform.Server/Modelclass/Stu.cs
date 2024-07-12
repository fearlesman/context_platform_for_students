using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace Student_platform.Server.Modelclass
{
    public class Stu
    {
        public string user_id { get; set; }

        public string stu_name { get; set; }

        public string stu_major { get; set; }

        public string stu_skill { get; set; }

        public string stu_character { get; set; }

        public bool has_team { get; set; }  

        public string team_identity { get; set; }



    }
}


