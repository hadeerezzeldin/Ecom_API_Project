using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Ecom.Core.Interfaces;
using Ecom.Core.Models;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using Ecom.Infrastructure.Repository;
using Ecom.Infrastructure.Repository.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

namespace Ecom.Infrastructure
{
    public static class infrasrtuctureRegisteration
    {
        public  static  IServiceCollection infrastructureConfigurarion(this IServiceCollection services , IConfiguration configuration)
            {
            //servivce add scoped
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<ICartReository, FakeCartRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Register Email Sender
            services.AddScoped<IEmailService, EmailService>();

            // register token
            services.AddScoped<IGenerateToken, GenerateToken>();

            //services.AddScoped<IConnectionMultiplexer>(sp =>
            //{
            //    var config = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"), true);
            //    return ConnectionMultiplexer.Connect(config);
            //});
            services.AddScoped<IImageManagmentService,ImageManagementService>();   
            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
            );
            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("cs"));
            });

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(o=>{
                o.Cookie.Name = "token";
                o.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
            }).AddJwtBearer(op =>
            {
                op.RequireHttpsMetadata = false;
                op.SaveToken = true;
                op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Secret"])),
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Token:Issuer"],
                    ValidateAudience = false,
                   ClockSkew = TimeSpan.Zero,
                  
                };
                op.Events = new JwtBearerEvents
                {
                  OnMessageReceived  = context =>
                  
                 {     context.Token = context.Request.Cookies["token"];
                     return Task.CompletedTask;
                 }
                };
            });

            return services;
            }
    }
}
