namespace OtpNetWebApp2.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Verify2FA { get; set; }
    }
}