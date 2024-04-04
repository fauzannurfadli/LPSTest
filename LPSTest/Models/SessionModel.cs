namespace LPSTest.Models
{
    public class SessionModel
    {
        public string Email { get; set; }
        public string accessToken { get; set; }
        public int expiresIn { get; set; }
        public string refreshToken { get; set; }
        public string tokenType { get; set; }
    }
}
