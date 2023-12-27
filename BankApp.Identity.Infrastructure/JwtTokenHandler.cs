using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BankApp.Identity.Core;
using BankApp.Identity.Core.Identity;
using BankApp.Identity.Core.Identity.Models;
using BankApp.Identity.Domain.User;
using Microsoft.IdentityModel.Tokens;

namespace BankApp.Identity.Infrastructure
{
    public class JwtTokenHandler : IJwtTokenHandler
    {
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtOptions _jwtOptions;

        public JwtTokenHandler(JwtOptions jwtOptions)
        {
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(jwtOptions.IssuerSigningKey)), jwtOptions.Algorithm);
            _jwtOptions = jwtOptions;
            // new TokenValidationParameters()
            // {
            //     ValidIssuer = jwtOptions.ValidIssuer,
            //     IssuerSigningKey = new SymmetricSecurityKey
            //         (Encoding.UTF8.GetBytes(jwtOptions.IssuerSigningKey)),
            //     ValidateIssuer = jwtOptions.ValidateIssuer,
            //     ValidateLifetime = jwtOptions.ValidateLifetime,
            //     ValidateIssuerSigningKey = jwtOptions.ValidateIssuerSigningKey,
            // });
        }


        public AuthorizationDto CreateToken(
            UserId userId,
            Roles role)
        {
            if (userId is null)
                throw new ArgumentException("User id cannot be empty.", nameof(userId));
            var utcNow = DateTime.UtcNow;
            var claims = new List<Claim> { new("userId", userId.ToString()) };
            var dateTime = utcNow.AddSeconds(_jwtOptions.ExpiryInSeconds);

            var token = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(_jwtOptions.ValidIssuer,
                claims: claims, notBefore: utcNow, expires: dateTime,
                signingCredentials: _signingCredentials));
            return new AuthorizationDto
            {
                AccessToken = token,
                RefreshToken = string.Empty,
                Expires = ((DateTimeOffset)dateTime).ToUnixTimeSeconds(),
                Role = role,
            };
        }
    }
}