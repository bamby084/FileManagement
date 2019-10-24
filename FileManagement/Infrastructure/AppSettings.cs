namespace FileManagement.Infrastructure
{
    public class AppSettings
    {
        public string SecretKey { get; set; }
        public int AccessTokenLifeTime { get; set; }
        public string PrivateAccessToken { get; set; }
    }
}
