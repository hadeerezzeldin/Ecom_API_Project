using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories{ get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            //base.OnModelCreating(modelBuilder);
        }
    }
}
