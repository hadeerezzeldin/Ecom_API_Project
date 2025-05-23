using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.Property(p=>p.Id).IsRequired();
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.NewPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.OldPrice).HasColumnType("decimal(18,2)");

            builder.HasData(
                new Product { Id =1 , ProductName="test", Description="test", NewPrice=1000, Quantity=3,categoryId=1}
                );
        }
    }
}
