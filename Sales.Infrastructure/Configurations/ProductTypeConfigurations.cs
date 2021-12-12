using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infrastructure.Configurations
{
    public class ProductTypeConfigurations : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductTypes");

            builder.HasIndex(s => s.TypeCode).IsUnique(false);
        }
    }
}
