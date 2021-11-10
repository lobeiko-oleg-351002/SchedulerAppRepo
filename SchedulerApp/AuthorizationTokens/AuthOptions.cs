﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.AuthorizationTokens
{
    public static class AuthOptions
    {
        public const string ISSUER = "SchedulerAuthServer"; 
        public const string AUDIENCE = "SchedulerAuthClient"; 
        public const string KEY = "mysupersecret_secretkey!123";   
        public const int LIFETIME = 10;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
