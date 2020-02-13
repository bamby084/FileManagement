using System.Collections.ObjectModel;
using System.Linq;

namespace FileManagement.Infrastructure
{
    public class AppSettings
    {
        public string SecretKey { get; set; }
        public int AccessTokenLifeTime { get; set; }
        public  PrivateAccessTokenCollection PrivateAccessTokens { get; set; }
    }

    public class PrivateAccessToken
    {
        public string Key { get; set; }
        public  string Value { get; set; }
    }

    public class PrivateAccessTokenCollection : Collection<PrivateAccessToken>
    {
        public string GetToken(string key)
        {
            var token = this.FirstOrDefault(t => t.Key == key);
            return token?.Value;
        }
    }
}
