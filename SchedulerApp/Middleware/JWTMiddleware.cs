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

        private async void attachUserToContext(HttpContext context, IStudentService studentService, string token)
        {
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
            TokenHandler.ValidateToken(token, AuthOptions.CreateValidationParameters(), out SecurityToken validatedToken);

            JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "nameid").Value);
            StudentViewModel identity = await studentService.Get(userId);

            var user = new ClaimsPrincipal(AuthOptions.CreateClaimsIdentity(identity, token));
            context.User = user;
        }
    }
}
