using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace Student_platform.Server
{
    public class Competition
    {
        public string cmpt_type { get; set; }

        public string cmpt_name { get; set; }

        public string cmpt_date { get; set; }

        public string cmpt_description { get; set; }

        public string cmpt_teacher_advise { get; set; }

        public string Show()
        {
            Competition cmpt = new Competition
            {
                cmpt_type = this.cmpt_type,
                cmpt_date = this.cmpt_date,
                cmpt_description = this.cmpt_description,
                cmpt_name = this.cmpt_name,
                cmpt_teacher_advise = this.cmpt_teacher_advise
            };
            string json = JsonSerializer.Serialize(cmpt);
            return json;
        }





    }
}
