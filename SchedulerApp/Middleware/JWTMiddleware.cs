using BLL.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using SchedulerApp.AuthorizationTokens;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Middleware
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;

        public JWTMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IStudentService studentService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                attachUserToContext(context, studentService, token);
            }

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IStudentService studentService, string token)
        {
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
            TokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "nameid").Value);
            StudentViewModel identity = studentService.Get(userId);

            var user = new ClaimsPrincipal(
                new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, $"User: {token}"),
                    new Claim(ClaimTypes.NameIdentifier, identity.Id.ToString()),
                    new Claim(ClaimTypes.Email, identity.Email),
                    //new Claim("isVerified", identity.IsVerified),
                    new Claim(ClaimTypes.Role, identity.Role.Name),
                }, "tokenAuthorization"));
            context.User = user;
        }
    }
}
