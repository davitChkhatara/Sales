using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infrastructure.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasOne(p => p.ProductType).WithMany(t => t.Products).HasForeignKey(p => p.ProductTypeId).IsRequired();

            builder.HasIndex(p => p.ProductTypeId).IsUnique(false);

        }
    }
}
