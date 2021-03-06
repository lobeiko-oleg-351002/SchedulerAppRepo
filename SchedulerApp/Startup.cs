using BLL.Converters;
using BLL.Converters.Interface;
using BLL.Services;
using BLL.Services.Interface;
using DAL.Repositories;
using DAL.Repositories.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SchedulerMigrations.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SchedulerApp.AuthorizationTokens;
using SchedulerApp.Middleware;
using BLL.ValidationServices.Interface;
using BLL.ValidationServices;
using Serilog;
using DAL.Repositories.Logging;
using SchedulerModels;
using BLL.Caching;
using SchedulerApp.Validation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using SchedulerApp.Caching;
using SchedulerViewModels;
using BLL.Caching.Base;
using System.IO;
using AppConfiguration;

namespace SchedulerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = AppConfiguration.AppConfiguration.GetAppSettings(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), Directory.GetCurrentDirectory());
            services.AddSingleton(x => appSettings);

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
               );

            services.AddDbContext<SchedulerDbContext>(options =>
                options.UseSqlServer(appSettings.ConnectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SchedulerDbContext>();

            services.AddMvc(options =>
                {
                    options.Filters.Add(new ValidationFilter());
                })
                    .AddFluentValidation(options =>
                    {
                        options.RegisterValidatorsFromAssemblyContaining<Startup>();
                    });

            services.AddTransient<CacheTypeResolver>();
            services.AddTransient<MemoryCacheService>();
            services.AddTransient<RedisCacheService>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = appSettings.RedisHostIp;
            });
            services.AddSingleton(provider => provider.GetService<CacheTypeResolver>().Resolve());


            services.AddControllers();
            services.AddScoped<ILogMessageManager<Student>, LogMessageManager<Student>>();
            services.AddScoped<IUserValidationService, UserValidationService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentConverter, StudentConverter>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<ILogMessageManager<Chief>, LogMessageManager<Chief>>();
            services.AddScoped<IChiefRepository, ChiefRepository>();
            services.AddScoped<IChiefConverter, ChiefConverter>();
            services.AddScoped<IChiefService, ChiefService>();

            services.AddScoped<ILogMessageManager<EventTemplate>, LogMessageManager<EventTemplate>>();
            services.AddScoped<IEventTemplateRepository, EventTemplateRepository>();
            services.AddScoped<IEventTemplateConverter, EventTemplateConverter>();
            services.AddScoped<IEventTemplateService, EventTemplateService>();

            services.AddScoped<ILogMessageManager<Subscriber>, LogMessageManager<Subscriber>>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<ISubscriberConverter, SubscriberConverter>();
            services.AddScoped<ISubscriberService, SubscriberService>();

            services.AddScoped<ILogMessageManager<SingleEvent>, LogMessageManager<SingleEvent>>();
            services.AddScoped<ISingleEventRepository, SingleEventRepository>();
            services.AddScoped<ISingleEventConverter, SingleEventConverter>();
            services.AddScoped<ISingleEventService, SingleEventService>();

            services.AddScoped<ILogMessageManager<WeeklyEventTime>, LogMessageManager<WeeklyEventTime>>();
            services.AddScoped<ILogMessageManager<SchedulerModels.DayOfWeek>, LogMessageManager<SchedulerModels.DayOfWeek>>();
            services.AddScoped<IDayOfWeekRepository, DayOfWeekRepository>();
            services.AddScoped<IWeeklyEventTimeRepository, WeeklyEventTimeRepository>();
            services.AddScoped<IWeeklyEventTimeConverter, WeeklyEventTimeConverter>();
            services.AddScoped<IWeeklyEventTimeService, WeeklyEventTimeService>();

            services.AddScoped<ILogMessageManager<WeeklyEvent>, LogMessageManager<WeeklyEvent>>();
            services.AddScoped<IWeeklyEventRepository, WeeklyEventRepository>();
            services.AddScoped<IWeeklyEventConverter, WeeklyEventConverter>();
            services.AddScoped<IWeeklyEventService, WeeklyEventService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            securityScheme, Array.Empty<string>()
                        }
                    });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = AuthOptions.CreateValidationParameters();
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
           // app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<JWTMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
