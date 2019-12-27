using BearerTokenGen.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BearerTokenGen.Infrastructure.Factories {
    public class TokenFactory : ITokenFactory {
        public TokenModel CreateToken(BearerTokenParamsModel bearerTokenParams) {
            try {
                var now = DateTime.UtcNow;
                var signingKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(bearerTokenParams.SigningKey));

                var jwt = new JwtSecurityToken(
                        issuer: bearerTokenParams.ValidIssuer,
                        audience: bearerTokenParams.ValidAudience,
                        notBefore: now,
                        expires: now.Add(TimeSpan.FromMinutes(1)),
                        signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                return new TokenModel { AccessToken = encodedJwt, IsValid = true };
            } catch(Exception ex) {
                return new TokenModel { AccessToken = String.Empty, IsValid = false, ErrorMessage = ex.Message };
            }
            
        }
    }
}
