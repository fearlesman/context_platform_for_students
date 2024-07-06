using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using Student_platform.Server.Modelclass;


namespace Student_platform.Server
{
    public class Team
    {
        public string team_name { get; set; }

        public string competition_name { get; set; }

        public string team_leader { get; set; }

        public string team_program_profile { get; set; }

        public Stu want_stu_info { get; set; }

        public Stu[] team_member { get; set; }


        public Team() { }

        public Team(string t_name, string c_name, string leader, string profile, Stu info, Stu[] member = null)
        {
            this.team_name = t_name;
            this.competition_name = c_name;
            this.team_leader = leader;
            this.team_program_profile = profile;
            this.team_member = member;
            this.want_stu_info = info;
        }


        public string Show()
        {
            Team team = new Team
            {
                team_leader = this.team_leader,
                team_name = this.team_name,
                team_member = this.team_member,
                competition_name = this.competition_name,
                team_program_profile = this.team_program_profile,
                want_stu_info = this.want_stu_info
            };
            string json = JsonSerializer.Serialize(team);
            return json;
        }

    }
}
