using Loja.Domain.Interfaces;
using Loja.Infra.CrossCutting.Identity.Authorization;
using Loja.Infra.CrossCutting.Identity.Models;
using Loja.Infra.CrossCutting.Identity.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra.CrossCutting.Identity.Services
{
    public class TokenService
    {

        public static string Secret = "fedaf7d8863b48e197b9287d492b708e";

        public static string GenerateToken(ApplicationUser user, IList<Claim> userClaims)
        {
        
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            
            var identityClaims = new ClaimsIdentity();

            identityClaims.AddClaims(userClaims);

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = TokenDescriptor.Issuer,
                //Audience = TokenDescriptor.Audience,
                NotBefore = DateTime.Now,
                Expires = DateTime.UtcNow.AddMinutes(TokenDescriptor.MinutesValid),
                Subject = identityClaims,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

    }
}
