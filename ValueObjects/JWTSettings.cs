namespace AspNet_Api_EfCore.ValueObjects
{
    public class JWTSettings
    {
        public string JwtKey { get; set; }
        public string ApiKeyName { get; set; }
        public string ApiKey { get; set; }
    }
}
