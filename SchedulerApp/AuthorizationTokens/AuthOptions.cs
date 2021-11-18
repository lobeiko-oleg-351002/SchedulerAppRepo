using Microsoft.IdentityModel.Tokens;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.AuthorizationTokens
{
    public static class AuthOptions
    {
        private const string ISSUER = "SchedulerAuthServer";
        private const string AUDIENCE = "SchedulerAuthClient";
        private const string KEY = "mysupersecret_secretkey!123";
        private const int LIFETIME = 10;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public static TokenValidationParameters CreateValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidIssuer = ISSUER,
                ValidateAudience = false,
                ValidAudience = AUDIENCE,
                ValidateLifetime = false,
                IssuerSigningKey = GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            };
        }

        public static ClaimsIdentity CreateClaimsIdentity(StudentViewModel student)
        {
            return NewClaimsIdentity(student, "User");
        }

        public static ClaimsIdentity CreateClaimsIdentity(StudentViewModel student, string token)
        {
            return NewClaimsIdentity(student, $"User: {token}");
        }

        private static ClaimsIdentity NewClaimsIdentity(StudentViewModel student, string user)
        {
            return new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user),
                new Claim(ClaimTypes.NameIdentifier, student.Id.ToString()),
                new Claim(ClaimTypes.Role, student.Role.Name),
            }, "tokenAuthorization");
        }

        public static UserToken CreateUserToken(StudentViewModel student)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = AuthOptions.CreateClaimsIdentity(student),
                SigningCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var response = new UserToken
            {
                Token = tokenHandler.WriteToken(token),
                UserName = student.Name
            };

            return response;
        }
    }
}
