using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Login;


namespace Application.Common.Authorization
{
    public static class TokenFactory
    {
        private static readonly string _key = new ConfigurationBuilder().AddJsonFile($"appsettings.json").Build().GetSection("JWT")["SigningKey"];

        public static string GenerateJwtAccessToken(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var cryptedKey = Encoding.UTF8.GetBytes(_key);

            var claims = new List<Claim>
            {
                new Claim("Id",user.Id.ToString()),
                new Claim("Email",user.Email),
                new Claim("FullName",user.FullName)

            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "locarise.com",
                Audience = "locarise.com",
                Expires = DateTime.UtcNow.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(cryptedKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);
        }

        public static string GenerateJwtTokenForSendingEmail(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = new ConfigurationBuilder().AddJsonFile($"appsettings.json").Build().GetSection("JWT")["SigningKey"];

            var cryptedKey = Encoding.UTF8.GetBytes(key);

            var claims = new List<Claim>
            {
                new Claim("Email",user.Email)

            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(cryptedKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public static Dictionary<string, string> ReturnCurrentUserClaims(HttpContext context)
        {

            string token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var claims = TokenReader(token);

            return claims;
        }

        public static Dictionary<string, string> TokenReader(string token)
        {

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                ValidateLifetime = false

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal.Claims.ToDictionary(c => c.Type, c => c.Value);


            //var decodedToken = tokenHandler.ReadJwtToken(token);
            //var claims = decodedToken.Claims.ToDictionary(c => c.Type, c=> c.Value);

            //return claims;

        }
    }
}
