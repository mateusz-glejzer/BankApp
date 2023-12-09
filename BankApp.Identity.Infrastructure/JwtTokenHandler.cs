using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BankApp.Identity.Core;
using BankApp.Identity.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace BankApp.Identity.Infrastructure
{
    public class JwtTokenHandler : IJwtProvider
    {
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtOptions _jwtOptions;

        public JwtTokenHandler(SigningCredentials signingCredentials, JwtOptions jwtOptions)
        {
            _signingCredentials = signingCredentials;
            _jwtOptions = jwtOptions;
        }

        public IdentityModel CreateToken(
            string userId,
            string role)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("User id cannot be empty.", nameof(userId));
            var utcNow = DateTime.UtcNow;
            var claims = new List<Claim> { new("userId", userId) };
            var dateTime = utcNow.AddSeconds(_jwtOptions.ExpiryInSeconds);

            var token = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(_jwtOptions.ValidIssuer,
                claims: claims, notBefore: utcNow, expires: dateTime,
                signingCredentials: _signingCredentials));
            return new IdentityModel
            {
                AccessToken = token,
                RefreshToken = string.Empty,
                Expires = ((DateTimeOffset)dateTime).ToUnixTimeSeconds(),
                Role = role,
            };
        }
    }
}