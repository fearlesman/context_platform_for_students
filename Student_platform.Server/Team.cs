using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;


namespace Student_platform.Server
{
    public class Team
    {
        public string team_name {  get; set; }

        public string competition_name {  get; set; }

        public string team_leader {  get; set; }

        public string team_program_prifiel {  get; set; }

        public Stu[] team_member {  get; set; }




    }
}
