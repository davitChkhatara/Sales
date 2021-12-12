using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infrastructure.Configurations
{
    public class SalesOrderConfigurations : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.ToTable("SalesOrders");

            builder.HasOne(s => s.Employee).WithMany(e => e.SalesOrders).HasForeignKey(e => e.EmployeeId).IsRequired();

            builder.HasIndex(s => s.EmployeeId).IsUnique(false);
        }
    }
}
