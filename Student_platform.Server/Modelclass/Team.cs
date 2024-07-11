using System;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
using System.Text.Json;


namespace Student_platform.Server.Modelclass
{

    public class Team_member
    {
        public string name { get; set; }

        public string id { get; set; }

        public string avatar { get; set; }

    }



    public class Team
    {
        public string name { get; set; }

        public string leaderid { get; set; }

        public string leaderName { get; set; }

        //public string leaderAvatar { get; set; }

        public List<Team_member> members { get; set; }

        public string race { get; set; }

        public string description { get; set; }

        public string type { get; set; }

        public int currentMembers { get; set; }

        public int totalMembers { get; set; }

        public string status { get; set; }

        public List<string> tags { get; set; }

        

     
    }
}
