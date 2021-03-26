namespace Core.Utilities.Security.JWT
{
    /* appsettings.json içinde ki değerleri atayabileceğim bir nesne oluşturduk */
	public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
