namespace Student_platform.Server.Modelclass
{
    public class Register
    {
        public string username {  get; set; }
        
        public string password {  get; set; }

        public string confirmPassword { get; set; }

        public string email {  get; set; }

        public string university { get; set; }

        public byte[] head_img { get; set; }
    }
}
