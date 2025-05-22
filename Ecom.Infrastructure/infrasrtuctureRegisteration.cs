using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using Ecom.Infrastructure.Repository;
using Ecom.Infrastructure.Repository.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
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

            return services;
            }
    }
}
