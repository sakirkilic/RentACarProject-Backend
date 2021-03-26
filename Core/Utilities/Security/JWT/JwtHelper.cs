using Core.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.IdentityModel.Tokens;


namespace Core.Utilities.Security.JWT
{

	public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } 
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;                                                      // appsettings.json'a ulaşmamızı sağlıyor.
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();       // TokenOptions bilgilerine ise buradan ulaşıyoruz.

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); //  appsettings.json -> AccessToken      ---ne zaman biteceke
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);      // appsettings.json -> SecurityKey       ---anahtar
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);  // nahtar ile algoritmayı veriyoruz -->
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims); //
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)   // System.IdentityModel.Tokens.Jwt kullanarak token'ımızın isteninlen bilgilerini girerek oluşturuyoruz. 
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)  // claimlerimizi oluşturuyoruz
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());    // burada atamaları kısalmak için Extensions->ClaimExtensions oluşturup onu kullandık
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
